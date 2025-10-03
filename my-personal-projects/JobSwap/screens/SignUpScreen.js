import { useContext, useState } from 'react';
import { Alert } from 'react-native';
import LoadingOverlay from '../components/UI/LoadingOverlay';
import AuthContent from '../components/Auth/AuthContent';
import { AuthContext } from '../store/auth-context';
import { createUser } from '../util/auth';
import { ref, update } from 'firebase/database';
import { db } from '../util/firebase';
import { USER_SETTINGS_DEFAULT, MATCHING_SETTINGS_DEFAULT } from '../constants/defaultSettings';
import { registerForPushAndStoreAsync } from '../util/push';
import { deleteUser } from 'firebase/auth';

function SignUpScreen() {
  const [isAuthenticating, setIsAuthenticating] = useState(false);
  const authCtx = useContext(AuthContext);

  async function signupHandler({ email, password }) {
    setIsAuthenticating(true);
    try {
      const token = await createUser(email, password);
      if (!token) throw new Error('Invalid register response.');
        
      authCtx.authenticate(token);
      
      registerForPushAndStoreAsync(token.userId).catch(()=>{});

      if (!token.idToken) throw new Error('Missing userId from register response.');
      await setDefaultSettings(token.userId);

    } catch (err) {
      console.log(err);
      Alert.alert('Authentication failed', err?.message ?? 'Could not create user, please check your input.');
    } finally {
      setIsAuthenticating(false); // da zaustavi spinner ucitavanja
    }
  }

  if (isAuthenticating) return <LoadingOverlay message="Creating user..." />;
  
  return <AuthContent isLogin={false} onAuthenticate={signupHandler} />;
}


async function setDefaultSettings(userId) {
  const updates = {
    [`users/${userId}/userSettings`]: USER_SETTINGS_DEFAULT,
    [`users/${userId}/matchingSettings`]: MATCHING_SETTINGS_DEFAULT,
  };
  try {
    await update(ref(db), updates);
  } catch (err) {

    console.error('Failed to create default settings, deleting user...', err);

    const currentUser = auth.currentUser;
    
    if (currentUser && currentUser.uid === userId) {
      try {
        await deleteUser(currentUser);
        console.log('User deleted because default settings setup failed');
      } catch (delErr) {
        console.error('Failed to delete user after settings failure:', delErr);
      }
    }

    throw err; // da zna i korisnik da je doslo do greske
  }
}

export default SignUpScreen;
