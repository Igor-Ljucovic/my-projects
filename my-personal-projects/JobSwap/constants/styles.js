import { StyleSheet, Dimensions } from 'react-native';

export const Colors = {
  primary100: '#f9beda',
  primary500: '#c30b64',
  primary800: '#610440',
  error100: '#fcdcbf',
  error500: '#f37c13',
}

export const userSettingsFormStyles = StyleSheet.create({
  container: { padding: 16, paddingBottom: 40 },
  center: { flex: 1, alignItems: 'center', justifyContent: 'center' },

  card: {
    backgroundColor: 'white',
    borderRadius: 12,
    padding: 12,
    marginBottom: 14,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 6 },
    shadowOpacity: 0.06,
    shadowRadius: 12,
    elevation: 3,
  },
  sectionTitle: { fontSize: 18, fontWeight: '600', marginBottom: 8 },

  field: { marginBottom: 10 },
  label: { fontSize: 13, color: '#555', marginBottom: 6 },
  input: {
    backgroundColor: '#F6F7F9',
    borderRadius: 10,
    paddingHorizontal: 12,
    paddingVertical: 10,
    fontSize: 16,
  },
  textarea: {
    minHeight: 84,
    textAlignVertical: 'top',
  },

  row: {
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: 6,
    justifyContent: 'space-between',
  },
  rowLabel: { fontSize: 16 },

  buttonsRow: {
    flexDirection: 'row',
    marginTop: 6,
    justifyContent: 'center',
  },
  saveBtn: {
    backgroundColor: '#2563eb',
    borderRadius: 12,
    padding: 10,
    alignItems: 'center',
    justifyContent: 'center',
  },
  resetBtn: {
    backgroundColor: '#ef4444',
    borderRadius: 12,
    padding: 10,
    alignItems: 'center',
    justifyContent: 'center',
  },

  toggleRow: {
    flexDirection: 'row',
    gap: 8,
  },
  toggleBtn: {
    flex: 1,
    borderRadius: 10,
    backgroundColor: '#E8EAF1',
    paddingVertical: 10,
    alignItems: 'center',
  },
  toggleActive: {
    backgroundColor: '#2563eb',
  },
  toggleText: {
    fontSize: 15,
    color: '#334155',
    fontWeight: '600',
  },
  toggleTextActive: {
    color: 'white',
  },

  helpText: {
    marginTop: 6,
    fontSize: 12,
    color: '#6b7280',
  },

  mapPickButton: {
    backgroundColor: '#2563eb',
    borderRadius: 10,
    paddingVertical: 10,
    paddingHorizontal: 28,
    alignItems: 'center',
    marginBottom: 10,
  },
  mapPickButtonText: {
    color: 'white',
    fontWeight: '600',
  },
  logoutButton: {
    backgroundColor: Colors.primary500,
    borderRadius: 10,
    paddingVertical: 3,
    paddingHorizontal: 10,
    alignItems: 'center',
    marginBottom: 10,
    flexDirection: 'row', 
    alignItems: 'center'
  }
});

const { width } = Dimensions.get('window');

export const homeScreenStyles = StyleSheet.create({
  container: { flex: 1, paddingTop: 36, backgroundColor: '#F6F7F9' },
  header: { fontSize: 22, fontWeight: '700', textAlign: 'center' },
  hint: { marginTop: 16, textAlign: 'center', opacity: 0.7, paddingHorizontal: 16 },
  page: { width, padding: 16, paddingTop: 20 },
  card: {
    flex: 1,
    backgroundColor: 'white',
    borderRadius: 16,
    padding: 16,
    elevation: 2,
    shadowColor: '#000',
    shadowOpacity: 0.1,
    shadowRadius: 8,
    shadowOffset: { width: 0, height: 4 },
    marginBottom: 40
  },
  title: { fontSize: 20, fontWeight: '700', marginBottom: 8 },
  line: { fontSize: 15, marginTop: 6 },
  label: { fontWeight: '600' },
  desc: { marginTop: 10, lineHeight: 20, opacity: 0.9 },
  swipeTip: { textAlign: 'center', marginTop: 16, opacity: 0.6 },
  counter: { position: 'absolute', bottom: 65, alignSelf: 'center', opacity: 0.6 },

  mapBtn: {
    marginTop: 12,
    alignSelf: 'flex-start',
    paddingHorizontal: 12,
    paddingVertical: 8,
    borderRadius: 10,
    backgroundColor: '#0A84FF',
  },
  mapBtnText: { color: 'white', fontWeight: '600' },
});