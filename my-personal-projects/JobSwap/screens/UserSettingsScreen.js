import { useContext, useEffect, useLayoutEffect, useMemo, useState } from 'react';
import { useRoute } from '@react-navigation/native';
import { Alert } from 'react-native';
import { ref, onValue, update, set } from 'firebase/database';
import { AuthContext } from '../store/auth-context';
import { db } from '../util/firebase';
import { USER_SETTINGS_DEFAULT } from '../constants/defaultSettings';
import IconButton from '../components/UI/IconButton';
import { parseLatLng } from '../util/geo';
import UserSettingsForm from '../components/UI/UserSettingsForm';


function UserSettingsScreen({ navigation }) {
  const { userId } = useContext(AuthContext);
  const route = useRoute();
  const authCtx = useContext(AuthContext);

  const DEFAULTS = { ...USER_SETTINGS_DEFAULT };
  const [form, setForm] = useState(DEFAULTS);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);

  const path = useMemo(
    () => (userId ? `users/${userId}/userSettings` : null),
    [userId]
  );

  const goHome = () => {
    navigation.reset({
      index: 0,
      routes: [{ name: 'HomeScreen' }],
    });
  };

  useEffect(() => {
    if (form.jobScheduleType !== 'fixed' && (form.jobStartTime || form.jobEndTime)) {
      setForm((prev) => ({ ...prev, jobStartTime: '', jobEndTime: '' }));
    }
  }, [form.jobScheduleType]);

  useEffect(() => {
    const picked = route.params?.pickedLocation;
    const target = route.params?.target; // 'jobLocation' i 'userLocation'
    if (!picked || !path) return;

    const latlng = `${picked.lat},${picked.lng}`;
    const isUser = target === 'userLocation';

    setForm(prev => ({
      ...prev,
      ...(isUser
        ? { userLocation: latlng }
        : { jobLocation: latlng, jobLocationName: picked.label || prev.jobLocationName || '' }
      ),
    }));

    const payload = isUser
      ? { userLocation: latlng }
      : { jobLocation: latlng, jobLocationName: picked.label || '' };

    (async () => {
      try { await update(ref(db, path), payload); } catch (e) {}
    })();

  }, [route.params?.pickedLocation, route.params?.target, path]);

  useLayoutEffect(() => {
    navigation.setOptions({
      headerLeft: () => (
        <IconButton
          icon="arrow-back"
          color="white"
          size={22}
          onPress={goHome}
        />
      ),
      title: 'User Settings',
    });
  }, [navigation, saving, loading]);

  useEffect(() => {
    if (!path) return;

    const unsubscribe = onValue(
      ref(db, path),
      (snap) => {
        const val = snap.val();
        if (val) {
          setForm({ ...DEFAULTS, ...val });
        } else {
          set(ref(db, path), DEFAULTS).catch(() => {});
          setForm(DEFAULTS);
        }
        setLoading(false);
      },
      (err) => {
        console.log('DB read failed:', err?.code, err?.message);
        Alert.alert('Error', 'Failed to load settings.');
        setLoading(false);
      }
    );

    return () => unsubscribe();
  }, [path]);

  function setText(key, transform = (v) => v) {
    return (txt) => setForm((prev) => ({ ...prev, [key]: transform(txt) }));
  }
  function setBool(key) {
    return (val) => setForm((prev) => ({ ...prev, [key]: val }));
  }
  function setValue(key, val) {
    setForm((prev) => ({ ...prev, [key]: val }));
  }

  async function handleSave() {
    if (!path) return;

    const TIME_RE = /^([01]\d|2[0-3]):[0-5]\d$/;

    const isFixed = form.jobScheduleType === 'fixed';
    const start = (form.jobStartTime || '').trim();
    const end   = (form.jobEndTime || '').trim();

    if (!isFixed && (start !== '' || end !== '')) {
      Alert.alert(
        'Schedule/Time mismatch',
        'You entered a start/end time but did not select the "fixed" schedule type. Either change schedule to "fixed" or clear the time fields.'
      );
      return;
    }

    if (isFixed) {
      if (!TIME_RE.test(start)) {
        Alert.alert('Invalid time', 'Please enter Start Time in HH:MM (00:00–23:59).');
        return;
      }
      if (!TIME_RE.test(end)) {
        Alert.alert('Invalid time', 'Please enter End Time in HH:MM (00:00–23:59).');
        return;
      }
      const toMinutes = (hhmm) => {
        const [h, m] = hhmm.split(':').map(n => parseInt(n, 10));
        return h * 60 + m;
      };
      if (toMinutes(end) <= toMinutes(start)) {
        Alert.alert(
          'Time range invalid',
          'End time must be later than start time for a fixed schedule.'
        );
        return;
      }
    }

    const cleaned = Object.fromEntries(
      Object.entries(form).map(([k, v]) => (typeof v === 'string' ? [k, v.trim()] : [k, v]))
    );
    if (!isFixed) {
      cleaned.jobStartTime = '';
      cleaned.jobEndTime = '';
    }

    setSaving(true);
    try {
      await update(ref(db, path), cleaned);
      Alert.alert('Saved', 'Your user settings have been updated.');
    } catch (e) {
      console.log('DB write failed:', e?.code, e?.message);
      Alert.alert('Error', 'Could not save your settings.');
    } finally {
      setSaving(false);
    }
  }

  const isFixed = form.jobScheduleType === 'fixed';
  const initialForPicker = parseLatLng(form.jobLocation) || null;

  return (
    <UserSettingsForm
      form={form}
      setText={setText}
      setBool={setBool}
      setValue={setValue}
      setForm={setForm}
      isFixed={isFixed}
      initialForPicker={initialForPicker}
      navigation={navigation}
      handleSave={handleSave}
      saving={saving}
      authCtx={authCtx}
    />
  );
}

export default UserSettingsScreen;