import { useContext, useState } from 'react';
import { Alert } from 'react-native';
import LoadingOverlay from '../components/UI/LoadingOverlay';
import AuthContent from '../components/Auth/AuthContent';
import { AuthContext } from '../store/auth-context';
import { createUser } from '../util/auth';
import { ref, update } from 'firebase/database';
import { db } from '../util/firebase';
import { USER_SETTINGS_DEFAULT, MATCHING_SETTINGS_DEFAULT } from '../constants/defaultSettings';

function SignUpScreen() {
  const [isAuthenticating, setIsAuthenticating] = useState(false);
  const authCtx = useContext(AuthContext);

  async function signupHandler({ email, password }) {
    setIsAuthenticating(true);
    try {
      const token = await createUser(email, password);
      if (!token) throw new Error('Invalid register response.');
        
      await authCtx.authenticate(token);

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
  await update(ref(db), updates);
}

export default SignUpScreen;
