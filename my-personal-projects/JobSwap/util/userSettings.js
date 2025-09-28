import { View, Text, TextInput, Pressable } from 'react-native';
import { formatHHMM, clampHHMM } from './time';
import { userSettingsFormStyles } from '../constants/styles';

function Field({ label, children }) {
  return (
    <View style={userSettingsFormStyles.field}>
      <Text style={userSettingsFormStyles.label}>{label}</Text>
      {children}
    </View>
  );
}

function TimeInput({ value, onChangeText, placeholder = 'HH:MM', editable = true }) {
  return (
    <TextInput
      value={value}
      onChangeText={(txt) => onChangeText(formatHHMM(txt))}
      onBlur={() => onChangeText(clampHHMM(value))}
      style={[userSettingsFormStyles.input, !editable && { opacity: 0.6 }]}
      editable={editable}
      keyboardType="number-pad"
      placeholder={placeholder}
      maxLength={5}
    />
  );
}

function ScheduleToggle({ value, onChange }) {
  const OPTIONS = [
    { key: 'fixed', label: 'Fixed' },
    { key: 'flexible', label: 'Flexible' },
    { key: 'rotating', label: 'Rotating' },
    { key: 'oncall', label: 'On-call' },
  ];
  return (
    <View style={[userSettingsFormStyles.toggleRow, { flexWrap: 'wrap' }]}>
      {OPTIONS.map((opt) => (
        <Pressable
          key={opt.key}
          onPress={() => onChange(opt.key)}
          style={[
            userSettingsFormStyles.toggleBtn,
            { flexBasis: '48%' },
            value === opt.key && userSettingsFormStyles.toggleActive,
          ]}
        >
          <Text style={[userSettingsFormStyles.toggleText, value === opt.key && userSettingsFormStyles.toggleTextActive]}>
            {opt.label}
          </Text>
        </Pressable>
      ))}
    </View>
  );
}

function WorkFromHomeToggle({ value, onChange }) {
  const OPTIONS = [
    { key: 'no', label: 'No' },
    { key: 'yes', label: 'Yes' },
    { key: 'hybrid', label: 'Hybrid' },
  ];
  return (
    <View style={userSettingsFormStyles.toggleRow}>
      {OPTIONS.map((opt) => (
        <Pressable
          key={opt.key}
          onPress={() => onChange(opt.key)}
          style={[userSettingsFormStyles.toggleBtn, value === opt.key && userSettingsFormStyles.toggleActive]}
        >
          <Text style={[userSettingsFormStyles.toggleText, value === opt.key && userSettingsFormStyles.toggleTextActive]}>
            {opt.label}
          </Text>
        </Pressable>
      ))}
    </View>
  );
}

export { Field, TimeInput, ScheduleToggle, WorkFromHomeToggle };