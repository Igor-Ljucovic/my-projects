import { useContext, useState } from 'react';
import { Alert } from 'react-native';
import LoadingOverlay from '../components/UI/LoadingOverlay';
import AuthContent from '../components/Auth/AuthContent';
import { AuthContext } from '../store/auth-context';
import { createUser } from '../util/auth';

function SignUpScreen() {
  const [isAuthenticating, setIsAuthenticating] = useState(false);
  const authCtx = useContext(AuthContext);

  async function signupHandler({ email, password }) {
    setIsAuthenticating(true);
    try {
      const token = await createUser(email, password);
      if (!token) throw new Error('No token returned from createUser.');
      authCtx.authenticate(token);
    } catch (err) {
      console.log(err);
      Alert.alert(
        'Authentication failed',
        err?.message ?? 'Could not create user, please check your input.'
      );
    } finally {
      setIsAuthenticating(false); // da zaustavi spinner ucitavanja
    }
  }

  if (isAuthenticating) {
    return <LoadingOverlay message="Creating user..." />;
  }

  return <AuthContent isLogin={false} onAuthenticate={signupHandler} />;
}

export default SignUpScreen;
