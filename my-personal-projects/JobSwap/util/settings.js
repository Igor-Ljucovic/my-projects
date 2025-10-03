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

function ScheduleTypeToggleUserSettings({ value, onChange }) {
  const OPTIONS = [
    { key: 'fixed', label: 'Fixed' },
    { key: 'flexible', label: 'Flexible' },
    { key: 'rotating', label: 'Rotating' },
    { key: 'on-call', label: 'On-call' },
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

function ScheduleTypesToggleMatchingSettings({ value = [], onChange }) {
  const OPTIONS = [
    { key: 'fixed', label: 'Fixed' },
    { key: 'flexible', label: 'Flexible' },
    { key: 'rotating', label: 'Rotating' },
    { key: 'on-call', label: 'On-call' },
  ];

  function toggle(key) {
    onChange(prev =>
      prev.includes(key)
        ? prev.filter(v => v !== key)
        : [...prev, key]
    );
  }

  return (
    <View style={[userSettingsFormStyles.toggleRow, { flexWrap: 'wrap' }]}>
      {OPTIONS.map(opt => {
        const selected = value.includes(opt.key);
        return (
          <Pressable
            key={opt.key}
            onPress={() => toggle(opt.key)}
            style={[
              userSettingsFormStyles.toggleBtn,
              { flexBasis: '48%' },
              selected && userSettingsFormStyles.toggleActive,
            ]}
            accessibilityRole="button"
            accessibilityState={{ selected }}
          >
            <Text
              style={[
                userSettingsFormStyles.toggleText,
                selected && userSettingsFormStyles.toggleTextActive,
              ]}
            >
              {opt.label}
            </Text>
          </Pressable>
        );
      })}
    </View>
  );
}

function WorkModelToggleUserSettings({ value, onChange }) {
  const OPTIONS = [
    { key: 'on-site', label: 'On-site' },
    { key: 'remote', label: 'Remote' },
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

function WorkModelsToggleMatchingSettings({ value = [], onChange }) {
  const OPTIONS = [
    { key: 'onsite', label: 'On-site' },
    { key: 'remote', label: 'Remote' },
    { key: 'hybrid', label: 'Hybrid' },
  ];

  function toggle(key) {
    onChange(prev =>
      prev.includes(key) ? prev.filter(v => v !== key) : [...prev, key]
    );
  }

  return (
    <View style={userSettingsFormStyles.toggleRow}>
      {OPTIONS.map(opt => {
        const selected = value.includes(opt.key);
        return (
          <Pressable
            key={opt.key}
            onPress={() => toggle(opt.key)}
            style={[
              userSettingsFormStyles.toggleBtn,
              selected && userSettingsFormStyles.toggleActive,
            ]}
            accessibilityRole="button"
            accessibilityState={{ selected }}
          >
            <Text
              style={[
                userSettingsFormStyles.toggleText,
                selected && userSettingsFormStyles.toggleTextActive,
              ]}
            >
              {opt.label}
            </Text>
          </Pressable>
        );
      })}
    </View>
  );
}

export { Field, TimeInput, ScheduleTypeToggleUserSettings, ScheduleTypesToggleMatchingSettings, WorkModelToggleUserSettings, WorkModelsToggleMatchingSettings };