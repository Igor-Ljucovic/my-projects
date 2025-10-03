const functions = require('firebase-functions');
const admin = require('firebase-admin');

try { admin.initializeApp(); } catch {}

const db = admin.database();
const messaging = admin.messaging();

// helper: figure out other participant from chatId "a_b"
function otherFromChatId(chatId, me) {
  const parts = (chatId || '').split('_');
  if (parts.length !== 2) return null;
  const [a, b] = parts;
  return a === me ? b : b === me ? a : null;
}

exports.notifyOnNewMessage = functions.database
  .ref('/chats/{chatId}/messages/{messageId}')
  .onCreate(async (snap, context) => {
    const { chatId, messageId } = context.params;
    const msg = snap.val() || {};

    const senderUid = (msg.senderId || '').toString();
    const text = (msg.text || '').toString().trim();
    if (!senderUid || !chatId) return null;

    // Determine recipient
    const recipientUid = otherFromChatId(chatId, senderUid);
    if (!recipientUid) return null;

    // Respect user preference: getMessageNotifications
    const settingsSnap = await db.ref(`users/${recipientUid}/userSettings/getMessageNotifications`).get();
    if (!settingsSnap.exists() || settingsSnap.val() !== true) {
      return null; // user opted out
    }

    // Load recipient’s push tokens
    const tokensSnap = await db.ref(`users/${recipientUid}/pushTokens`).get();
    if (!tokensSnap.exists()) return null;

    const tokens = Object.keys(tokensSnap.val() || {}).filter(Boolean);
    if (!tokens.length) return null;

    // Load sender info (jobTitle for the body format)
    const senderJobTitleSnap = await db.ref(`users/${senderUid}/userSettings/jobTitle`).get();
    const senderJobTitle = (senderJobTitleSnap.val() || '').toString().trim();

    // Build notification payload
    // Title must be "JobSwap", body "user: jobTitle" as you requested.
    // You can also include the message preview if you want.
    const notification = {
      title: 'JobSwap',
      body: `${senderUid}: ${senderJobTitle || 'New message'}`,
    };

    // Data you can use for deep linking into the chat
    const data = {
      chatId,
      senderUid,
      messageId,
      // include anything else you need
    };

    // Send to all tokens
    const message = {
      notification,
      data,
      tokens, // sendEachForMulticast
    };

    // If you use Expo push tokens (ExponentPushToken[...] strings),
    // you’ll typically send through Expo’s push API instead of FCM directly.
    // If you configured FCM directly in app.json/eas.json, these will be device FCM tokens.
    const res = await messaging.sendEachForMulticast(message);

    // Optionally prune invalid tokens
    const toRemove = [];
    res.responses.forEach((r, idx) => {
      if (!r.success) {
        const code = r.error && r.error.code;
        if (code && (code.includes('registration-token-not-registered') || code.includes('invalid-argument'))) {
          toRemove.push(tokens[idx]);
        }
      }
    });
    if (toRemove.length) {
      const updates = {};
      toRemove.forEach(t => { updates[`users/${recipientUid}/pushTokens/${t.replace(/[.#$/\[\]]/g,'_')}`] = null; });
      await db.ref().update(updates);
    }

    return null;
  });
