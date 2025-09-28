import { Modal, View, Pressable, StyleSheet, Dimensions, Text } from 'react-native';

const { width: SCREEN_W, height: SCREEN_H } = Dimensions.get('window');

export default function DropdownMenu({
  visible,
  anchor,
  onClose,
  options = [],
  maxWidth = 220,
}) {
  if (!visible || !anchor) return null;

  const PADDING = 8;
  const menuWidth = Math.min(maxWidth, SCREEN_W - 2 * PADDING);
  const calculatedTop = anchor.y + anchor.height + 6;
  const calculatedRight = Math.max(PADDING, SCREEN_W - (anchor.x + anchor.width));
  const top = Math.min(calculatedTop, SCREEN_H - PADDING - 44 * options.length - 12);

  return (
    <Modal visible transparent animationType="fade" onRequestClose={onClose}>
      <Pressable style={styles.backdrop} onPress={onClose} />

      <View style={[styles.menu, { top, right: calculatedRight, width: menuWidth }]}>
        {options.map(({ label, onPress }, idx) => (
          <Pressable
            key={label}
            style={({ pressed }) => [
              styles.item,
              idx !== options.length - 1 && styles.itemDivider,
              pressed && styles.itemPressed,
            ]}
            onPress={() => {
              onClose?.();
              setTimeout(() => onPress?.(), 0);
            }}
          >
            <Text style={styles.itemText}>{label}</Text>
          </Pressable>
        ))}
      </View>
    </Modal>
  );
}

const styles = StyleSheet.create({
  backdrop: {
    flex: 1,
    backgroundColor: 'rgba(0,0,0,0.1)',
  },
  menu: {
    position: 'absolute',
    backgroundColor: '#222',
    borderRadius: 12,
    paddingVertical: 4,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 6 },
    shadowOpacity: 0.12,
    shadowRadius: 12,
    elevation: 8,
    overflow: 'hidden',
  },
  item: {
    height: 44,
    justifyContent: 'center',
    paddingHorizontal: 12,
  },
  itemDivider: {
    borderBottomWidth: StyleSheet.hairlineWidth,
    borderBottomColor: '#444',
  },
  itemPressed: {
    backgroundColor: '#333',
  },
  itemText: {
    fontSize: 16,
    color: 'white',
  },
});
