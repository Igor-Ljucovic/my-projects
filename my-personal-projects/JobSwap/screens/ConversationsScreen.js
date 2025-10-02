import { useContext, useEffect, useState } from 'react';
import { ActivityIndicator, FlatList, Pressable, StyleSheet, Text, View } from 'react-native';
import { useNavigation } from '@react-navigation/native';
import { ref, onValue, off, get } from 'firebase/database';
import { db } from '../util/firebase';
import { AuthContext } from '../store/auth-context';
import { parseLatLng, getHaversineDistanceKmFrom2LatLngPoints } from '../util/geo';
import { hasText } from '../util/ui';
import { homeScreenStyles } from '../constants/styles';

function otherFromChatId(chatId, me) {
  const [a, b] = (chatId || '').split('_');
  return a === me ? b : b === me ? a : null;
}

export default function ConversationsScreen() {
  const navigation = useNavigation();
  const { userId } = useContext(AuthContext);

  const [loading, setLoading] = useState(true);
  const [list, setList] = useState([]);

  useEffect(() => {
    if (!userId) return;

    const userChatsRef = ref(db, `userChats/${userId}`);

    const cb = onValue(
      userChatsRef,
      async (snap) => {
        try {
          const rows = [];
          snap.forEach((child) => {
            const chatId = child.key;
            const val = child.val() || {};
            rows.push({
              chatId,
              otherUid: otherFromChatId(chatId, userId),
              lastText: (val.lastMessage ?? '').toString().trim(),
              lastAt: Number(val.updatedAt) || 0,
            });
          });

          if (rows.length === 0) {
            setList([]);
            setLoading(false);
            return;
          }

          const myLocStrSnap = await get(
            ref(db, `users/${userId}/userSettings/userLocation`)
          );
          const myLoc = parseLatLng((myLocStrSnap.val() ?? '').toString());

          const usersSnap = await get(ref(db, 'users'));

          const enriched = rows.map((c) => {
            const usNode = usersSnap.child(`${c.otherUid}/userSettings`);
            const jobTitle = (usNode.child('jobTitle').val() ?? '').toString().trim();
            const jobLoc = parseLatLng((usNode.child('jobLocation').val() ?? '').toString());
            const jobLocName = (usNode.child('jobLocationName').val() ?? '').toString().trim();

            let distanceKm = null;
            if (myLoc && jobLoc) {
              const d = getHaversineDistanceKmFrom2LatLngPoints(myLoc, jobLoc);
              if (Number.isFinite(d)) distanceKm = d;
            }

            const title = hasText(jobTitle)
              ? `${jobTitle}${
                  Number.isFinite(distanceKm)
                    ? ` (~${distanceKm.toFixed(1)} km${
                        hasText(jobLocName) ? `, ${jobLocName}` : ''
                      })`
                    : ''
                }`
              : Number.isFinite(distanceKm)
              ? `${distanceKm.toFixed(1)} km${hasText(jobLocName) ? `, ${jobLocName}` : ''}`
              : 'Conversation';

            return {
              ...c,
              distanceKm,
              title,
              otherProfile: {
                jobTitle,
                jobLocation: jobLoc ? `${jobLoc.lat},${jobLoc.lng}` : '',
                jobLocationName: jobLocName,
                jobScheduleType: (usNode.child('jobScheduleType').val() ?? '').toString().trim(),
                workModel: (usNode.child('workModel').val() ?? '').toString().trim(),
                jobStartTime: (usNode.child('jobStartTime').val() ?? '').toString().trim(),
                jobEndTime: (usNode.child('jobEndTime').val() ?? '').toString().trim(),
                jobCountry: (usNode.child('jobCountry').val() ?? '').toString().trim(),
                jobDescription: (usNode.child('jobDescription').val() ?? '').toString().trim(),
                jobCategory: (usNode.child('jobCategory').val() ?? '').toString().trim(),
                jobTags: (usNode.child('jobTags').val() ?? '').toString().trim(),
              },
            };
          });

          enriched.sort((a, b) => (b.lastAt || 0) - (a.lastAt || 0));
          setList(enriched);
        } catch (e) {
          console.log('ConversationsScreen error:', e);
        } finally {
          setLoading(false);
        }
      },
      (err) => {
        console.log('ConversationsScreen DB error:', err?.code, err?.message);
        setLoading(false);
      }
    );

    return () => off(userChatsRef, 'value', cb);
  }, [userId]);

  if (!userId) return null;

  return (
    <View style={styles.container}>
      <Text style={styles.header}>Your conversations</Text>

      {loading ? (
        <ActivityIndicator size="large" style={{ marginTop: 16 }} />
      ) : list.length === 0 ? (
        <Text style={styles.hint}>No conversations with other users yet.</Text>
      ) : (
        <FlatList
          data={list}
          keyExtractor={(item) => item.chatId}
          ItemSeparatorComponent={() => <View style={styles.sep} />}
          renderItem={({ item }) => (
            <Pressable
              style={styles.row}
              onPress={() =>
                navigation.navigate('Chat', {
                  chatId: item.chatId,
                  otherUid: item.otherUid,
                  otherProfile: item.otherProfile || null,
                })
              }
            >
              <View style={{ flex: 1 }}>
                <Text style={styles.titleText}>{item.title}</Text>
                {hasText(item.lastText) && (
                  <Text numberOfLines={1} style={styles.previewText}>
                    {item.lastText}
                  </Text>
                )}
              </View>
            </Pressable>
          )}
        />
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 16 },
  header: { ...homeScreenStyles.header, marginBottom: 8 },
  hint: { ...homeScreenStyles.hint, marginTop: 12 },
  sep: { height: 8 },
  row: { backgroundColor: '#fff', borderRadius: 12, padding: 14, elevation: 1 },
  titleText: { fontSize: 16, fontWeight: '700', color: '#111827' },
  subText: { fontSize: 14, color: '#4b5563', marginTop: 2 },
  previewText: { fontSize: 13, color: '#6b7280', marginTop: 6 },
});
