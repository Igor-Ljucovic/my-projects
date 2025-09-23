import axios from 'axios';
import { FIREBASE_API_KEY } from '@env';

async function authenticate(mode, email, password) {
  // mode je 'signUp' ili 'signInWithPassword' koji pisu dole
  const url = `https://identitytoolkit.googleapis.com/v1/accounts:${mode}?key=${FIREBASE_API_KEY}`;
  try {
    const { data } = await axios.post(url, {
      email,
      password,
      returnSecureToken: true,
    });
    return {
      idToken: data.idToken,
      refreshToken: data.refreshToken,
      expiresIn: Number(data.expiresIn),
      userId: data.localId,
      email: data.email,
    };
  } catch (err) {
    throw new Error(err?.response?.data?.error?.message);
  }
}

export async function createUser(email, password) {
  const res = await authenticate('signUp', email, password);
  return res.idToken;
}

export async function login(email, password) {
  const res = await authenticate('signInWithPassword', email, password);
  return res.idToken;
}

