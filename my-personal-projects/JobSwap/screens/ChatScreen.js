import { useContext, useEffect, useMemo, useRef, useState } from 'react';
import { View, Text, TextInput, Pressable, FlatList, KeyboardAvoidingView, Platform, Alert, Keyboard } from 'react-native';
import { SafeAreaView, useSafeAreaInsets } from 'react-native-safe-area-context';
import { useHeaderHeight } from '@react-navigation/elements';
import { ref, onValue, off, push, set, serverTimestamp, update } from 'firebase/database';
import { db } from '../util/firebase';
import { AuthContext } from '../store/auth-context';
import { chatScreenStyles } from '../constants/styles';

export default function ChatScreen({ route, navigation }) {
  const { userId } = useContext(AuthContext);
  const { chatId, otherUid, otherProfile } = route.params || {};
  const [text, setText] = useState('');
  const [messages, setMessages] = useState([]);
  const inputRef = useRef(null);
  const listRef = useRef(null);

  const insets = useSafeAreaInsets();
  const headerHeight = useHeaderHeight();
  const [composerH, setComposerH] = useState(52);
  const [isKeyboardVisible, setKeyboardVisible] = useState(false);

  useEffect(() => {
    const showSub = Keyboard.addListener('keyboardDidShow', () => setKeyboardVisible(true));
    const hideSub = Keyboard.addListener('keyboardDidHide', () => setKeyboardVisible(false));
    return () => {
      showSub.remove();
      hideSub.remove();
    };
  }, []);

  useEffect(() => {
    const title = (otherProfile?.jobTitle && otherProfile.jobTitle.trim()) || 'Chat';
    navigation.setOptions({ title });
  }, [navigation, otherProfile?.jobTitle]);

  const msgsRef = useMemo(() => (chatId ? ref(db, `chats/${chatId}/messages`) : null), [chatId]);

  useEffect(() => {
    if (!msgsRef) return;
    const unsub = onValue(msgsRef, (snap) => {
      const list = [];
      snap.forEach((childSnap) => {
        const v = childSnap.val();
        list.push({
          id: childSnap.key,
          text: v?.text ?? '',
          from: v?.from ?? '',
          createdAt: v?.createdAt ?? 0,
        });
      });
      list.sort((a, b) => (a.createdAt ?? 0) - (b.createdAt ?? 0));
      setMessages(list);
    });
    return () => {
      off(msgsRef);
      unsub?.();
    };
  }, [msgsRef]);

  useEffect(() => {
    if (!listRef.current) return;
    const t = setTimeout(() => {
      listRef.current?.scrollToEnd?.({ animated: true });
    }, 60);
    return () => clearTimeout(t);
  }, [messages.length, isKeyboardVisible]);

  const canSend = Boolean(text.trim()) && Boolean(userId) && Boolean(chatId) && Boolean(otherUid);

  async function send() {
    const trimmed = text.trim();
    if (!trimmed) return;

    if (!userId || !chatId || !otherUid) {
      Alert.alert('Chat not ready', 'Missing chat parameters.');
      return;
    }
    if (!msgsRef) {
      Alert.alert('Chat not ready', 'Message reference unavailable.');
      return;
    }

    const msg = { text: trimmed, from: userId, createdAt: serverTimestamp() };

    try {
      const newMsgRef = push(msgsRef);
      await set(newMsgRef, msg);

      const updates = {};
      updates[`userChats/${userId}/${chatId}`] = {
        with: otherUid,
        lastMessage: trimmed,
        updatedAt: serverTimestamp(),
      };
      updates[`userChats/${otherUid}/${chatId}`] = {
        with: userId,
        lastMessage: trimmed,
        updatedAt: serverTimestamp(),
      };
      await update(ref(db), updates);

      setText('');
    } catch (e) {
      console.log('send message failed:', e?.code, e?.message);
      Alert.alert('Failed to send', e?.message || 'Please try again.');
    }
  }

  const renderItem = ({ item }) => {
    const mine = item.from === userId;
    return (
      <View style={[chatScreenStyles.bubble, mine ? chatScreenStyles.mine : chatScreenStyles.their]}>
        <Text style={chatScreenStyles.msgText}>{item.text}</Text>
      </View>
    );
  };

  return (
    <SafeAreaView style={chatScreenStyles.wrap} edges={['top', 'left', 'right']}>
      <KeyboardAvoidingView
        behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
        style={{ flex: 1 }}
        keyboardVerticalOffset={Platform.OS === 'ios' ? headerHeight : 0}
      >
        <FlatList
          ref={listRef}
          data={messages}
          keyExtractor={(m) => m.id}
          renderItem={renderItem}
          style={{ flex: 1 }}
          contentContainerStyle={[
            chatScreenStyles.listContent,
            { paddingBottom: composerH + insets.bottom + 4 },
          ]}
        />

        <View
          style={[
            chatScreenStyles.composerRow,
            { paddingBottom: Math.max(insets.bottom, 0) + (isKeyboardVisible ? composerH * (1/3) : 0), },
          ]}
           onLayout={(e) => setComposerH(e.nativeEvent.layout.height)}
         >
          <TextInput
            ref={inputRef}
            value={text}
            onChangeText={setText}
            placeholder="Type a message..."
            placeholderTextColor="#94a3b8"
            style={chatScreenStyles.input}
            multiline
            onSubmitEditing={() => {
              if (Platform.OS === 'ios' && !text.includes('\n')) send();
            }}
          />
          <Pressable
            onPress={send}
            style={[chatScreenStyles.sendBtn, !canSend && { opacity: 0.5 }]}
            hitSlop={8}
            disabled={!canSend}
            android_ripple={{ color: 'rgba(255,255,255,0.1)', borderless: false }}
          >
            <Text style={chatScreenStyles.sendTxt}>Send</Text>
          </Pressable>
        </View>
      </KeyboardAvoidingView>
    </SafeAreaView>
  );
}
