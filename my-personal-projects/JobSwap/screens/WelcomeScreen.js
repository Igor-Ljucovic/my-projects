import { useContext, useEffect } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { ref, update } from 'firebase/database';
import { db } from '../util/firebase';
import { AuthContext } from '../store/auth-context';

function WelcomeScreen() {

  const { userId } = useContext(AuthContext);
  console.log('[WelcomeScreen] effect ran. userId =', userId);
  useEffect(() => {
  if (!userId) return;

  const path = `users/${userId}/profileSettings`;
  console.log('Writing to:', path);

  // THIS IS JUST A TEST
  update(ref(db, path), {
    getMessageNotifications: true,
    privateProfile: true,
    })
      .then(() => console.log('DB write OK'))
      .catch((e) => console.log('DB write FAILED:', e.code, e.message));
  }, [userId]);
  // TEST--

  return (
    <View style={styles.rootContainer}>
      <Text style={styles.title}>Welcome!</Text>
      <Text>You authenticated successfully!</Text>
    </View>
  );
}

export default WelcomeScreen;

const styles = StyleSheet.create({
  rootContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: 32,
  },
  title: {
    fontSize: 20,
    fontWeight: 'bold',
    marginBottom: 8,
  },
});