import { useLayoutEffect } from 'react';
import { View, Text, StyleSheet, ScrollView } from 'react-native';

function MatchingSettingsScreen({ navigation }) {
  useLayoutEffect(() => {
    navigation.setOptions({ title: 'Matching Settings' });
  }, [navigation]);

  // TODO: Replace with your real form
  return (
    <ScrollView contentContainerStyle={styles.container}>
      <Text style={styles.h1}>Matching Settings</Text>
      <Text>Here you’ll edit matchingSettings (e.g., job tags, max distance, languages...).</Text>
    </ScrollView>
  );
}

export default MatchingSettingsScreen;

const styles = StyleSheet.create({
  container: { padding: 16 },
  h1: { fontSize: 22, fontWeight: '600', marginBottom: 12 },
});