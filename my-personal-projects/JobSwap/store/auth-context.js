import { createContext, useState } from 'react';

export const AuthContext = createContext({
  token: '',
  userId: null,
  isAuthenticated: false,
  authenticate: (_payload) => {},
  logout: () => {},
});

function AuthContextProvider({ children }) {
  const [token, setToken] = useState(null);
  const [userId, setUserId] = useState(null);
  

  function authenticate(token) {
    setToken(token.idToken);
    setUserId(token.userId);
  }

  function logout() {
    setToken(null);
    setUserId(null);
  }

  const value = {
    token,
    userId,
    isAuthenticated: !!token,
    authenticate,
    logout,
  };
  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

export default AuthContextProvider;