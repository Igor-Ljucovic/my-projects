import * as Notifications from 'expo-notifications';
import * as Device from 'expo-device';
import { ref, update } from 'firebase/database';
import { db } from './firebase';

export async function registerForPushAndStoreAsync(userId) {
  if (!Device.isDevice) return null;

  const { status: existingStatus } = await Notifications.getPermissionsAsync();
  let finalStatus = existingStatus;
  if (existingStatus !== 'granted') {
    const { status } = await Notifications.requestPermissionsAsync();
    finalStatus = status;
  }
  if (finalStatus !== 'granted') return null;

  await Notifications.setNotificationChannelAsync('default', {
    name: 'default',
    importance: Notifications.AndroidImportance.DEFAULT,
  });

  const tokenResp = await Notifications.getExpoPushTokenAsync();
  const token = tokenResp?.data;
  if (!token || !userId) return null;

  await update(ref(db, `users/${userId}/pushTokens`), { [sanitizeKey(token)]: true });
  return token;
}

function sanitizeKey(s) {
  return (s || '').replace(/[.#$/\[\]]/g, '_');
}
