import { useContext, useEffect, useLayoutEffect, useMemo, useState } from 'react';
import { useRoute } from '@react-navigation/native';
import { Alert } from 'react-native';
import { AuthContext } from '../store/auth-context';
import { USER_SETTINGS_DEFAULT } from '../constants/defaultSettings';
import IconButton from '../components/UI/IconButton';
import { parseLatLng } from '../util/geo';
import UserSettingsForm from '../components/UI/UserSettingsForm';
import { getUserSettings, patchUserSettings } from '../util/db_rest';


function UserSettingsScreen({ navigation }) {
  const authCtx = useContext(AuthContext);
  const { userId, token: authToken } = authCtx || {};
  const route = useRoute();

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
    const target = route.params?.target; // 'jobLocation' ili 'userLocation'
    if (!picked || !userId || !authToken) return;

    const latlng = `${picked.lat},${picked.lng}`;
    const isUser = target === 'userLocation';

    // local state update-uje odmah
    setForm((prev) => ({
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
      try {
        await patchUserSettings(userId, payload, authToken);
      } catch {
        // da se ne pojavi error ako ne uspe update settings-a novog
      }
    })();
  }, [route.params?.pickedLocation, route.params?.target, userId, authToken]);

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

  // pocetno ucitavanje settings-a kad se stranica otvori
  useEffect(() => {
    if (!userId || !authToken) return;

    let alive = true;
    (async () => {
      setLoading(true);
      try {
        const val = await getUserSettings(userId, authToken);
        if (!alive) return;

        if (val) {
          setForm({ ...DEFAULTS, ...val });
        } else {
          // ako nekom greskom nema settings-a, postavi default
          await patchUserSettings(userId, DEFAULTS, authToken);
          if (!alive) return;
          setForm(DEFAULTS);
        }
      } catch (err) {
        console.log('REST read failed:', err?.message || err);
        Alert.alert('Error', 'Failed to load settings.');
      } finally {
        if (alive) setLoading(false);
      }
    })();

    return () => { alive = false; };
  }, [userId, authToken]);

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
    if (!userId || !authToken) return;

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
      await patchUserSettings(userId, cleaned, authToken);
      Alert.alert('Saved', 'Your user settings have been updated.');
    } catch (e) {
      console.log('REST write failed:', e?.message || e);
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
