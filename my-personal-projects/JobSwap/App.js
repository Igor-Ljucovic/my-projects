import { useContext } from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { View } from 'react-native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { StatusBar } from 'expo-status-bar';
import LogInScreen from './screens/LogInScreen';
import SignUpScreen from './screens/SignUpScreen';
import HomeScreen from './screens/HomeScreen';
import { Colors } from './constants/styles';
import AuthContextProvider, { AuthContext } from './store/auth-context';
import UserSettingsScreen from './screens/UserSettingsScreen';
import MatchingSettingsScreen from './screens/MatchingSettingsScreen';
import SettingsButton from './components/UI/SettingsButton';
import ChatsButton from './components/UI/ChatsButton';
import MapPickerScreen from './screens/MapPickerScreen';
import ChatScreen from './screens/ChatScreen';
import ConversationsScreen from './screens/ConversationsScreen';

const Stack = createNativeStackNavigator();

function AuthStack() {
  return (
    <Stack.Navigator
      screenOptions={{
        headerStyle: { backgroundColor: Colors.primary500 },
        headerTintColor: 'white',
        contentStyle: { backgroundColor: Colors.primary100 },
      }}
    >
      <Stack.Screen name="LogIn" component={LogInScreen} title="Log in" />
      <Stack.Screen name="SignUp" component={SignUpScreen} title = "Sign up" />
    </Stack.Navigator>
  );
}

function AuthenticatedStack() {
  return (
    <Stack.Navigator
      screenOptions={{
        headerStyle: { backgroundColor: Colors.primary500 },
        headerTintColor: 'white',
        contentStyle: { backgroundColor: Colors.primary100 },
      }}
    >
      <Stack.Screen
        name="HomeScreen"
        component={HomeScreen}
        options={{
        headerRight: ({ tintColor }) => (
          <View style={{ flexDirection: 'row', gap: 8, paddingRight: 4 }}>
            <ChatsButton tintColor={tintColor} />
            <SettingsButton tintColor={tintColor} />
          </View>
        ),
        title: 'JobSwap',
      }}
      />
      <Stack.Screen
        name="Conversations"
        component={ConversationsScreen}
        options={{ title: 'Conversations' }}
      />
      <Stack.Screen 
        name="MapPicker" 
        component={MapPickerScreen} 
        options={{ title: 'Pick Location' }} 
      />
      <Stack.Screen
        name="Chat"
        component={ChatScreen}
        options={{ title: 'Chat' }}
      />
      <Stack.Screen
        name="UserSettings"
        component={UserSettingsScreen}
        options={{ title: 'User Settings' }}
      />
      <Stack.Screen
        name="MatchingSettings"
        component={MatchingSettingsScreen}
        options={{ title: 'Matching Settings' }}
      />
    </Stack.Navigator>
  );
}

function Navigation() {
  const authCtx = useContext(AuthContext);

  return (
    <NavigationContainer>
      {!authCtx.isAuthenticated && <AuthStack />}
      {authCtx.isAuthenticated && <AuthenticatedStack />}
    </NavigationContainer>
  );
}

export default function App() {
  return (
    <>
      <StatusBar style="light" />
      <AuthContextProvider>
        <Navigation />
      </AuthContextProvider>
    </>
  );
}