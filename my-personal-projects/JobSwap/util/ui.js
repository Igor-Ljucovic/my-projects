import { homeScreenStyles } from '../constants/styles';
import { Text } from 'react-native';

function toKey(v) {
  return (v ?? '').toString().trim().toLowerCase();
}

function nodeToStringSet(node) {
  const val = node?.val();
  const out = new Set();
  if (val && typeof val === 'object') {
    for (const v of Object.values(val)) {
      if (typeof v === 'string' && v.trim()) out.add(v.trim().toLowerCase());
    }
  }
  return out;
}

function hasText(v) {
  return typeof v === 'string' && v.trim().length > 0;
}

function Label({ children }) {
  return <Text style={homeScreenStyles.label}>{children} </Text>;
}

function renderLine(label, value) {
  if (value == null) return null;
  const str = typeof value === 'string' ? value.trim() : String(value);
  if (!hasText(str)) return null;
  return (
    <Text style={homeScreenStyles.line}>
      <Label>{label}:</Label> {str}
    </Text>
  );
}

export { toKey, nodeToStringSet, hasText, Label, renderLine };