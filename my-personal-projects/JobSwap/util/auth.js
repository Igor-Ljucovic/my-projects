import { createUserWithEmailAndPassword, signInWithEmailAndPassword } from 'firebase/auth';
import { auth } from '../util/firebase';

// modovi su 'signUp' i 'signInWithPassword'
async function authenticate(mode, email, password) {
  try {
    const cred =
      mode === 'signUp'
        ? await createUserWithEmailAndPassword(auth, email, password)
        : await signInWithEmailAndPassword(auth, email, password);

    const user = cred.user;
    const idToken = await user.getIdToken();

    return {
      idToken,
      userId: user.uid,
      email: user.email ?? email,
    };
  } catch (err) {
    const msg = err?.code ?? err?.message ?? 'AUTH_ERROR';
    throw new Error(msg);
  }
}

export function createUser(email, password) {
  return authenticate('signUp', email, password);
}

export function login(email, password) {
  return authenticate('signInWithPassword', email, password);
}