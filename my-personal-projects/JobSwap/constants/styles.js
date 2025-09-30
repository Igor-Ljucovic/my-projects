import { StyleSheet } from 'react-native';

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