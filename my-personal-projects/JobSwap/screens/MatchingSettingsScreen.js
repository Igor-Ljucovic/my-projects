import { useContext, useEffect, useMemo, useState } from 'react';
import { Alert } from 'react-native';
import { ref, onValue, update, set } from 'firebase/database';
import { AuthContext } from '../store/auth-context';
import { db } from '../util/firebase';
import { MATCHING_SETTINGS_DEFAULT } from '../constants/defaultSettings';
import UserMatchingSettingsForm from '../components/UI/UserMatchingSettingsForm';


function MatchingSettingsScreen() {
  const { userId } = useContext(AuthContext);

  const DEFAULTS = { ...MATCHING_SETTINGS_DEFAULT };
  const [form, setForm] = useState(DEFAULTS);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);

  const path = useMemo(
    () => (userId ? `users/${userId}/matchingSettings` : null),
    [userId]
  );

  useEffect(() => {
    setForm(prev => {
      if ((prev.jobStartTime ?? '') === '' && (prev.jobEndTime ?? '') === '') {
        return prev;
      }
      return { ...prev, jobStartTime: '', jobEndTime: '' };
    });
  }, [form.jobScheduleTypes]);

  useEffect(() => {
  if (!path) return;

  const unsub = onValue(
    ref(db, path),
    async (snap) => {
      const val = snap.val();

      if (!val) {
        const defaultsPayload = {
          ...DEFAULTS,
          jobScheduleTypes:
            Array.isArray(DEFAULTS.jobScheduleTypes) && DEFAULTS.jobScheduleTypes.length
              ? DEFAULTS.jobScheduleTypes
              : { 0: '' },
        };
        try { await set(ref(db, path), defaultsPayload); } catch {}
        setForm({ ...DEFAULTS, jobScheduleTypes: [] });
        setLoading(false);
        return;
      }

      const merged = { ...DEFAULTS, ...val };
      // sacuvaj jobScheduleTypes i workModel kao niz (objekat u FirebBase-u), 
      // ako nema nijedan izabran, sacuvaj {0: ''} da bi objekat mogao da se sacuva,
      // a ako ima bar 1 element, onda sacuvaj normalno objekat
      // normalizacija jobScheduleTypes u niz
      const jst = merged.jobScheduleTypes;
      merged.jobScheduleTypes =
        Array.isArray(jst) ? jst
        : (jst && typeof jst === 'object')
          ? (() => {
              const keys = Object.keys(jst).sort((a,b)=>a-b);
              if (keys.length === 1 && keys[0] === '0' && jst['0'] === '') return [];
              return keys.map(k => jst[k]).filter(Boolean);
            })()
        : (typeof jst === 'string' && jst) ? [jst]
        : [];

      setForm(merged);
      setLoading(false);
    },
    (err) => {
      console.log('DB read failed:', err?.code, err?.message);
      Alert.alert('Error', 'Failed to load settings.');
      setLoading(false);
    }
  );

  return () => unsub();
}, [path]);

  function setText(key, transform = (v) => v) {
    return (txt) => setForm((prev) => ({ ...prev, [key]: transform(txt) }));
  }

  async function handleSave() {
  if (!path) return;

  const TIME_RE = /^([01]\d|2[0-3]):[0-5]\d$/;

  const rawSchedule =
    Array.isArray(form.jobScheduleTypes)
      ? form.jobScheduleTypes
      : (typeof form.jobScheduleTypes === 'string' && form.jobScheduleTypes)
        ? [form.jobScheduleTypes]
        : (form.jobScheduleTypes && typeof form.jobScheduleTypes === 'object')
          ? Object.values(form.jobScheduleTypes)
          : [];

  const VALID_SCHEDULE = new Set(['fixed', 'flexible', 'rotating', 'oncall']);
  const scheduleArr = Array.from(
    new Set(
      rawSchedule
        .map(v => (v ?? '').toString().trim())
        .filter(v => v && VALID_SCHEDULE.has(v))
    )
  );

  const hasFixed = scheduleArr.includes('fixed');

  if (hasFixed) {
    if (!TIME_RE.test(form.jobStartTime || '')) {
      Alert.alert('Invalid time', 'Please enter Start Time in HH:MM (00:00–23:59).');
      return;
    }
    if (!TIME_RE.test(form.jobEndTime || '')) {
      Alert.alert('Invalid time', 'Please enter End Time in HH:MM (00:00–23:59).');
      return;
    }
  }

  const rawWfh =
    Array.isArray(form.workModels)
      ? form.workModels
      : (typeof form.workModels === 'string' && form.workModels)
        ? [form.workModels]
        : (form.workModels && typeof form.workModels === 'object')
          ? Object.values(form.workModels)
          : [];

  const VALID_WFH = new Set(['onsite', 'remote', 'hybrid']);
  const wfhArr = Array.from(
    new Set(
      rawWfh
        .map(v => (v ?? '').toString().trim())
        .filter(v => v && VALID_WFH.has(v))
    )
  );

  const payload = { ...form };

  for (const k of Object.keys(payload)) {
    if (typeof payload[k] === 'string') payload[k] = payload[k].trim();
  }

  payload.jobScheduleTypes = scheduleArr.length ? scheduleArr : { 0: '' };
  payload.workModels = wfhArr.length ? wfhArr : { 0: '' };

  if (!hasFixed) {
    payload.jobStartTime = '';
    payload.jobEndTime = '';
  }

  setSaving(true);
  try {
    await update(ref(db, path), payload);
    Alert.alert('Saved', 'Your matching settings have been updated.');
  } catch (e) {
    console.log('DB write failed:', e?.code, e?.message);
    Alert.alert('Error', 'Could not save your settings.');
  } finally {
    setSaving(false);
  }
}

  return (
    <UserMatchingSettingsForm
      form={form}
      setText={setText}
      setForm={setForm}
      handleSave={handleSave}
      saving={saving}
    />
  );
}

export default MatchingSettingsScreen;