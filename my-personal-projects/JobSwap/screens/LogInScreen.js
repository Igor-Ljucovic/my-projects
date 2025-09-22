import { useContext, useState } from 'react';
import { Alert } from 'react-native';

import AuthContent from '../components/Auth/AuthContent';
import LoadingOverlay from '../components/UI/LoadingOverlay';
import { AuthContext } from '../store/auth-context';
import { login } from '../util/auth';

function LogInScreen() {
  const [isAuthenticating, setIsAuthenticating] = useState(false);
  const authCtx = useContext(AuthContext);

  async function loginHandler({ email, password }) {
    setIsAuthenticating(true);
    try {
      const token = await login(email, password);
      if (!token) throw new Error('No token returned from login.');
      authCtx.authenticate(token);
    } catch (err) {
      console.log(err);
      Alert.alert(
        'Authentication failed!',
        err?.message ?? 'Could not log you in. Please check your credentials!'
      );
    } finally {
      setIsAuthenticating(false); // da zaustavi spinner ucitavanja
    }
  }

  if (isAuthenticating) {
    return <LoadingOverlay message="Logging you in..." />;
  }

  return <AuthContent isLogin={true} onAuthenticate={loginHandler} />;
}

export default LogInScreen;
