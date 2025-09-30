import { useContext, useEffect, useState } from 'react';
import { ActivityIndicator, FlatList, StyleSheet, Text, View } from 'react-native';
import { ref, onValue } from 'firebase/database';
import { db } from '../util/firebase';
import { AuthContext } from '../store/auth-context';

function WelcomeScreen() {
  const { userId } = useContext(AuthContext);
  const [titles, setTitles] = useState([]);
  const [loading, setLoading] = useState(true);
  const [needsMore, setNeedsMore] = useState(false);
  const [requiredN, setRequiredN] = useState(0);

  useEffect(() => {
    if (!userId) return;

    const toKey = (v) => (v ?? '').toString().trim().toLowerCase();
    const toMins = (hhmm) => {
      const m = /^([01]\d|2[0-3]):([0-5]\d)$/.exec((hhmm ?? '').toString().trim());
      return m ? Number(m[1]) * 60 + Number(m[2]) : NaN;
    };
    const arrayNodeToSet = (node) => {
      const val = node?.val();
      const out = new Set();
      if (val && typeof val === 'object') {
        for (const v of Object.values(val)) {
          if (typeof v === 'string' && v.trim()) out.add(v.trim().toLowerCase());
        }
      }
      return out;
    };
    const parseLatLng = (s) => {
      if (!s || typeof s !== 'string') return null;
      const parts = s.split(',').map(t => t.trim());
      if (parts.length !== 2) return null;
      const lat = Number(parts[0]), lng = Number(parts[1]);
      return Number.isFinite(lat) && Number.isFinite(lng) ? { lat, lng } : null;
    };
    const haversineKm = (a, b) => {
      const R = 6371; // km
      const dLat = (b.lat - a.lat) * Math.PI / 180;
      const dLng = (b.lng - a.lng) * Math.PI / 180;
      const s1 = Math.sin(dLat/2), s2 = Math.sin(dLng/2);
      const aa = s1*s1 + Math.cos(a.lat*Math.PI/180) * Math.cos(b.lat*Math.PI/180) * s2*s2;
      const c = 2 * Math.atan2(Math.sqrt(aa), Math.sqrt(1-aa));
      return R * c;
    };

    const usersRef = ref(db, 'users');
    const unsub = onValue(
      usersRef,
      (snap) => {
        try {
          const fTitle           = toKey(snap.child(`${userId}/matchingSettings/jobTitle`).val());
          const fCategory        = toKey(snap.child(`${userId}/matchingSettings/jobCategory`).val());
          const fLanguage        = toKey(snap.child(`${userId}/matchingSettings/jobLanguage`).val());
          const fQualifications  = toKey(snap.child(`${userId}/matchingSettings/jobQualifications`).val());
          const fTags            = toKey(snap.child(`${userId}/matchingSettings/jobTags`).val());
          const fLocationName    = toKey(snap.child(`${userId}/matchingSettings/jobLocationName`).val());

          const fMinStart = toMins(snap.child(`${userId}/matchingSettings/minJobStartTime`).val());
          const fMaxStart = toMins(snap.child(`${userId}/matchingSettings/maxJobStartTime`).val());
          const hasMin = !Number.isNaN(fMinStart);
          const hasMax = !Number.isNaN(fMaxStart);

          const fScheduleSet = arrayNodeToSet(snap.child(`${userId}/matchingSettings/jobScheduleTypes`));
          const fWorkSet     = arrayNodeToSet(snap.child(`${userId}/matchingSettings/workModels`));

          const myLocStr = snap.child(`${userId}/userSettings/userLocation`).val();
          const myLoc = parseLatLng((myLocStr ?? '').toString());
          const maxKmRaw = snap.child(`${userId}/matchingSettings/maxJobLocationDistanceKm`).val();
          const maxKm = Number(maxKmRaw);
          const hasDist = !!myLoc && Number.isFinite(maxKm) && maxKm > 0;

          const required = Math.max(
            0,
            Number(snap.child(`${userId}/matchingSettings/minimumNumberOfCriteriaToMatch`).val()) || 0
          );
          const setFlags = [
            !!fTitle, !!fCategory, !!fLanguage, !!fQualifications, !!fTags, !!fLocationName,
            hasMin, hasMax,
            fScheduleSet.size > 0,
            fWorkSet.size > 0,
            hasDist,
          ];
          const setCount = setFlags.filter(Boolean).length;

          setRequiredN(required);

          if (setCount < required) {
            setNeedsMore(true);
            setTitles([]);
            return;
          } else {
            setNeedsMore(false);
          }

          const acc = [];

          snap.forEach((child) => {
            if (child.key === userId) return;

            const us = child.child('userSettings');

            const rawTitle        = (us.child('jobTitle').val() ?? '').toString().trim();
            const oTitle          = toKey(rawTitle);
            const oCategory       = toKey(us.child('jobCategory').val());
            const oLanguage       = toKey(us.child('jobLanguage').val());
            const oQualifications = toKey(us.child('jobQualifications').val());
            const oTags           = toKey(us.child('jobTags').val());
            const oLocationName   = toKey(us.child('jobLocationName').val());

            const oSchedule       = toKey(us.child('jobScheduleType').val());
            const oWorkModel      = toKey(us.child('workModel').val());

            const oStart = toMins(us.child('jobStartTime').val());
            const oEnd   = toMins(us.child('jobEndTime').val());

            const textOk =
              oTitle.includes(fTitle) &&
              oCategory.includes(fCategory) &&
              oLanguage.includes(fLanguage) &&
              oQualifications.includes(fQualifications) &&
              oTags.includes(fTags) &&
              oLocationName.includes(fLocationName);

            const minOk = !hasMin || (!Number.isNaN(oStart) && oStart >= fMinStart);
            const maxOk = !hasMax || (!Number.isNaN(oEnd)   && oEnd   <= fMaxStart);

            const scheduleOk = fScheduleSet.size === 0 || fScheduleSet.has(oSchedule);
            const workOk     = fWorkSet.size === 0     || fWorkSet.has(oWorkModel);

            let distOk = true;
            if (hasDist) {
              const otherJobLocStr = us.child('jobLocation').val();
              const otherJobLoc = parseLatLng((otherJobLocStr ?? '').toString());
              distOk = !!otherJobLoc && haversineKm(myLoc, otherJobLoc) <= maxKm;
            }

            if (textOk && minOk && maxOk && scheduleOk && workOk && distOk && rawTitle) {
              acc.push(rawTitle);
            }
          });

          const unique = Array.from(new Set(acc)).sort((a, b) => a.localeCompare(b));
          setTitles(unique);
        } catch (e) {
          console.log('[WelcomeScreen] parse error:', e);
        } finally {
          setLoading(false);
        }
      },
      (err) => {
        console.log('[WelcomeScreen] onValue error:', err?.code, err?.message);
        setLoading(false);
      }
    );

    return () => unsub();
  }, [userId]);

  if (!userId) return null;

  return (
    <View style={styles.rootContainer}>
      <Text style={styles.title}>Welcome!</Text>
      <Text style={styles.subtitle}>Job titles from other users (filtered by your matching settings):</Text>

      {loading ? (
        <ActivityIndicator size="large" style={{ marginTop: 12 }} />
      ) : needsMore ? (
        <Text style={styles.empty}>
          Set at least {requiredN} matching criteria to see results.
        </Text>
      ) : titles.length === 0 ? (
        <Text style={styles.empty}>No job titles found yet.</Text>
      ) : (
        <FlatList
          style={{ alignSelf: 'stretch', marginTop: 12 }}
          data={titles}
          keyExtractor={(item, index) => `${item}-${index}`}
          renderItem={({ item }) => <Text style={styles.item}>• {item}</Text>}
          contentContainerStyle={{ paddingHorizontal: 16, paddingBottom: 24 }}
        />
      )}
    </View>
  );
}

export default WelcomeScreen;

const styles = StyleSheet.create({
  rootContainer: { flex: 1, padding: 24, paddingTop: 40 },
  title: { fontSize: 22, fontWeight: 'bold' },
  subtitle: { marginTop: 6, fontSize: 16, opacity: 0.8 },
  empty: { marginTop: 12, fontStyle: 'italic', opacity: 0.7 },
  item: { fontSize: 16, paddingVertical: 6 },
});
