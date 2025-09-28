import { useContext, useEffect, useLayoutEffect, useMemo, useState } from 'react';
import { useRoute } from '@react-navigation/native';
import { View, Text, ActivityIndicator, Alert } from 'react-native';
import { ref, onValue, update, set } from 'firebase/database';
import { AuthContext } from '../store/auth-context';
import { db } from '../util/firebase';
import { PROFILE_SETTINGS_DEFAULT } from '../constants/settings';
import IconButton from '../components/UI/IconButton';
import { parseLatLng } from '../util/geo';
import { userSettingsFormStyles } from '../constants/styles';
import UserSettingsForm from '../components/UI/UserSettingsForm';


function UserSettingsScreen({ navigation }) {
  const { userId } = useContext(AuthContext);
  const route = useRoute();

  const DEFAULTS = { ...PROFILE_SETTINGS_DEFAULT };
  const [form, setForm] = useState(DEFAULTS);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);

  const path = useMemo(
    () => (userId ? `users/${userId}/profileSettings` : null),
    [userId]
  );

  const goHome = () => {
    navigation.reset({
      index: 0,
      routes: [{ name: 'Welcome' }],
    });
  };

  useEffect(() => {
    if (form.jobScheduleType !== 'fixed' && (form.jobStartTime || form.jobEndTime)) {
      setForm((prev) => ({ ...prev, jobStartTime: '', jobEndTime: '' }));
    }
  }, [form.jobScheduleType]);

  useEffect(() => {
    const sub = navigation.addListener('beforeRemove', (e) => {
      if (e.data.action.type === 'GO_BACK' || e.data.action.type === 'POP') {
        e.preventDefault();
        goHome();
      }
    });
    return sub;
  }, [navigation]);

  useEffect(() => {
    const picked = route.params?.pickedLocation;
    if (!picked || !path) return;

    const latlng = `${picked.lat},${picked.lng}`;

    setForm((prev) => ({
      ...prev,
      jobLocation: latlng,
      jobLocationName: picked.label || prev.jobLocationName || '',
    }));

    (async () => {
      try {
        await update(ref(db, path), {
          jobLocation: latlng,
          jobLocationName: picked.label || '',
        });
      } catch (e) {
        Alert.alert('Error', 'Could not save the selected location.');
      }
    })();

    navigation.setParams?.({ pickedLocation: undefined });
  }, [route.params?.pickedLocation, path, navigation]);

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

    if (form.jobScheduleType === 'fixed') {
      if (!TIME_RE.test(form.jobStartTime || '')) {
        Alert.alert('Invalid time', 'Please enter Start Time in HH:MM (00:00–23:59).');
        return;
      }
      if (!TIME_RE.test(form.jobEndTime || '')) {
        Alert.alert('Invalid time', 'Please enter End Time in HH:MM (00:00–23:59).');
        return;
      }
    }

    const cleaned = Object.fromEntries(
      Object.entries(form).map(([k, v]) => (typeof v === 'string' ? [k, v.trim()] : [k, v]))
    );

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

  if (loading) {
    return (
      <View style={userSettingsFormStyles.center}>
        <ActivityIndicator size="large" />
        <Text style={{ marginTop: 8 }}>Loading settings...</Text>
      </View>
    );
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
    />
  );
}

export default UserSettingsScreen;