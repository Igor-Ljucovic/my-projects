import { useState } from 'react';
import { Alert, StyleSheet, View } from 'react-native';
import { useNavigation } from '@react-navigation/native';
import FlatButton from '../UI/FlatButton';
import AuthForm from './AuthForm';
import { Colors } from '../../constants/styles';


function AuthContent({ isLogin, onAuthenticate }) {
  const navigation = useNavigation();

  const [credentialsInvalid, setCredentialsInvalid] = useState({
    email: false,
    password: false,
    confirmPassword: false,
  });

  function switchAuthModeHandler() {
    if (isLogin) {
      navigation.navigate('SignUp');
    } else {
      navigation.navigate('LogIn');
    }
  }

  function submitHandler(credentials) {
    let { email, password, confirmPassword } = credentials;

    email = email.trim();
    password = password.trim();

    // something@something.something
    const emailIsValid = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
    
    // pazi, ovde ako promenis nesto, moras i ispod u poruci o gresci!
    const passwordHasMinLength = password.length >= 10;
    const passwordHasUpper = /[A-Z]/.test(password); 
    const passwordHasLower = /[a-z]/.test(password);
    const passwordHasNumber = /[0-9]/.test(password); // 1 malo, 1 veliko slovo i 1 broj

    const passwordsAreEqual = password === confirmPassword; 

    const passwordIsValid = passwordHasMinLength && passwordHasUpper
    && passwordHasLower && passwordHasNumber;

    if (!emailIsValid) {
      // neke mail-ove kao sto je nesto@nesto.j nece FireBase prihvatiti i bacice svoju
      // gresku, jer zna da ne postoji takav TLD (top-level domen) - "INVALID_EMAIL"
      Alert.alert(
        'Email invalid', 
        'Enter a valid email address.'
      );
      return;
    }

    if (!passwordIsValid) {
      Alert.alert(
        'Weak password',
        'Password must be at least 10 characters long, include at least 1 uppercase letter, 1 lowercase letter, 1 number.'
      );
      return;
    }

    if (!isLogin && !passwordsAreEqual) {
      Alert.alert('Invalid input', 'Please check your entered credentials.');
      setCredentialsInvalid({
        email: !emailIsValid,
        password: !passwordIsValid,
        confirmPassword: !passwordIsValid || !passwordsAreEqual,
      });
      return;
    }
    onAuthenticate({ email, password });
  }

  return (
    <View style={styles.authContent}>
      <AuthForm
        isLogin={isLogin}
        onSubmit={submitHandler}
        credentialsInvalid={credentialsInvalid}
      />
      <View style={styles.buttons}>
        <FlatButton onPress={switchAuthModeHandler}>
          {isLogin ? 'Create a new user' : 'Log in instead'}
        </FlatButton>
      </View>
    </View>
  );
}

export default AuthContent;

const styles = StyleSheet.create({
  authContent: {
    marginTop: 64,
    marginHorizontal: 32,
    padding: 16,
    borderRadius: 8,
    backgroundColor: Colors.primary800,
    elevation: 2,
    shadowColor: 'black',
    shadowOffset: { width: 1, height: 1 },
    shadowOpacity: 0.35,
    shadowRadius: 4,
  },
  buttons: {
    marginTop: 8,
  },
});