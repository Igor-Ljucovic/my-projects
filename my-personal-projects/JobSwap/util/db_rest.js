import { rtdb, withAuth } from './api';


export async function getUserSettings(userId, idToken) {
  const { data } = await rtdb.get(`/users/${userId}/userSettings.json`, {
    params: withAuth({}, idToken),
  });
  return data || null;
}

export async function patchUserSettings(userId, payload, idToken) {
  const { data } = await rtdb.patch(`/users/${userId}/userSettings.json`, payload, {
    params: withAuth({}, idToken),
  });
  return data;
}