import { useNavigation } from '@react-navigation/native';
import IconButton from './IconButton';

export default function ChatsButton({ tintColor = 'white' }) {
  const navigation = useNavigation();

  return (
    <IconButton
      icon="chatbubbles"
      color={tintColor}
      size={24}
      onPress={() => navigation.navigate('Conversations')}
    />
  );
}