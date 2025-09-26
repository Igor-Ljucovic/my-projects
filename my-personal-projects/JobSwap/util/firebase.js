import { initializeApp } from 'firebase/app';
import { getDatabase } from 'firebase/database';
import { initializeAuth, getReactNativePersistence } from 'firebase/auth';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { FIREBASE_API_KEY, FIREBASE_APP_ID, FIREBASE_PROJECT_ID, FIREBASE_DATABASE_URL } from '@env';

const firebaseConfig = {
  apiKey: FIREBASE_API_KEY,
  appId: FIREBASE_APP_ID,
  projectId: FIREBASE_PROJECT_ID,
  databaseURL: FIREBASE_DATABASE_URL
};

// moze i automatski za config jer imamo samo 1 app, ali zbog konzistentnosti
// stavicemo ovako
const app = initializeApp(firebaseConfig);
export const db = getDatabase(app);

// mora za react native i ovaj deo da se doda
export const auth = initializeAuth(app, {
  persistence: getReactNativePersistence(AsyncStorage),
});