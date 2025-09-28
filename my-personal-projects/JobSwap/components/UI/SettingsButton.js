import { useRef, useState } from 'react';
import { View } from 'react-native';
import { useNavigation } from '@react-navigation/native';
import IconButton from './IconButton';
import DropdownMenu from './DropdownMenu';

export default function SettingsButton({ tintColor = 'white' }) {
  const navigation = useNavigation();

  const gearRef = useRef(null);
  const [menuVisible, setMenuVisible] = useState(false);
  const [anchor, setAnchor] = useState(null);

  function openMenu() {
    gearRef.current?.measureInWindow?.((x, y, width, height) => {
      setAnchor({ x, y, width, height });
      setMenuVisible(true);
    });
  }

  return (
    <View style={{ flexDirection: 'row', gap: 8, paddingRight: 4 }}>
      <View ref={gearRef} collapsable={false}>
        <IconButton icon="settings" color={tintColor} size={24} onPress={openMenu} />
      </View>

      <DropdownMenu
        visible={menuVisible}
        anchor={anchor}
        onClose={() => setMenuVisible(false)}
        options={[
          {
            label: 'User Settings',
            onPress: () => navigation.navigate('UserSettings'),
          },
          {
            label: 'Matching Settings',
            onPress: () => navigation.navigate('MatchingSettings'),
          },
        ]}
      />
    </View>
  );
}
