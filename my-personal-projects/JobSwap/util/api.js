import axios from 'axios';
import { FIREBASE_API_KEY, FIREBASE_DATABASE_URL } from '@env';


export const rtdb = axios.create({
  baseURL: FIREBASE_DATABASE_URL,
  timeout: 15000,
});

export function withAuth(params = {}, idToken) {
  const authParam = idToken ? { auth: idToken } : {};
  return { ...params, ...authParam };
}

export const authRest = axios.create({
  baseURL: 'https://identitytoolkit.googleapis.com/v1',
  timeout: 15000,
  params: { key: FIREBASE_API_KEY },
});
