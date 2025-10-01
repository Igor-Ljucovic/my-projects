import { useContext, useEffect, useRef, useState } from 'react';
import { ActivityIndicator, Alert, Dimensions, FlatList, PanResponder, Pressable, Text, View } from 'react-native';
import { useNavigation } from '@react-navigation/native';
import { ref, onValue, query, orderByChild, equalTo } from 'firebase/database';
import { db } from '../util/firebase';
import { AuthContext } from '../store/auth-context';
import { parseLatLng, getHaversineDistanceKmFrom2LatLngPoints } from '../util/geo'
import { parseTimeToMins } from '../util/time';
import { toKey, nodeToStringSet, hasText, Label, renderLine } from '../util/ui';
import { homeScreenStyles } from '../constants/styles';

const { width } = Dimensions.get('window');

function renderTimeLine(us) {
  const a = (us.jobStartTime || '').trim();
  const b = (us.jobEndTime || '').trim();
  if (!hasText(a) || !hasText(b)) return null;
  return renderLine('Time', `${a}–${b}`);
}

export default function HomeScreen() {
  const navigation = useNavigation();
  const { userId } = useContext(AuthContext);
  const [cards, setCards] = useState([]);
  const [loading, setLoading] = useState(true);
  const [needsMore, setNeedsMore] = useState(false);
  const [requiredN, setRequiredN] = useState(0);
  const [index, setIndex] = useState(0);

  const listRef = useRef(null);

  const pan = useRef(
    PanResponder.create({
      onMoveShouldSetPanResponder: (_e, g) => Math.abs(g.dx) > 12 && Math.abs(g.dy) < 20,
      onPanResponderRelease: (_e, g) => {
        if (g.dx > 60 && Math.abs(g.vx) > 0.3) {
          Alert.alert('Nothing, messaging will be added here');
        }
      },
    })
  ).current;

  useEffect(() => {
    if (!userId) return;

    const usersRef = query(
      ref(db, 'users'),
      orderByChild('userSettings/publicProfile'),
      equalTo(true)
    );
    const unsub = onValue(
      usersRef,
      (snap) => {
        try {
          const matchPath       = `${userId}/matchingSettings`;
          const fTitle          = toKey(snap.child(`${matchPath}/jobTitle`).val());
          const fCategory       = toKey(snap.child(`${matchPath}/jobCategory`).val());
          const fLanguage       = toKey(snap.child(`${matchPath}/jobLanguage`).val());
          const fQualifications = toKey(snap.child(`${matchPath}/jobQualifications`).val());
          const fTags           = toKey(snap.child(`${matchPath}/jobTags`).val());
          const fLocationName   = toKey(snap.child(`${matchPath}/jobLocationName`).val());

          const fMinStart = parseTimeToMins(snap.child(`${matchPath}/jobStartTime`).val());
          const fMaxEnd   = parseTimeToMins(snap.child(`${matchPath}/jobEndTime`).val());
          const hasMin    = !Number.isNaN(fMinStart);
          const hasMax    = !Number.isNaN(fMaxEnd);

          const fScheduleSet = nodeToStringSet(snap.child(`${matchPath}/jobScheduleTypes`));
          const fWorkSet     = nodeToStringSet(snap.child(`${matchPath}/workModels`));

          const maxKmRaw = snap.child(`${matchPath}/maxJobLocationDistanceKm`).val();
          const maxKm    = Number(maxKmRaw);
          const myLocStr = snap.child(`${userId}/userSettings/userLocation`).val();
          const myLoc    = parseLatLng((myLocStr ?? '').toString());
          const hasDist  = !!myLoc && Number.isFinite(maxKm) && maxKm > 0;

          const required = Math.max(0, Number(snap.child(`${matchPath}/minimumNumberOfCriteriaToMatch`).val()) || 0);
          setRequiredN(required);

          const setFlags = [
            !!fTitle, !!fCategory, !!fLanguage, !!fQualifications, !!fTags, !!fLocationName,
            hasMin, hasMax,
            fScheduleSet.size > 0,
            fWorkSet.size > 0,
          ];
          const setCount = setFlags.filter(Boolean).length;
          if (setCount < required) {
            setNeedsMore(true);
            setCards([]);
            setLoading(false);
            return;
          } else {
            setNeedsMore(false);
          }

          const acc = [];

          snap.forEach((child) => {
            if (child.key === userId) return;
            const us = child.child('userSettings');
            const raw = {
              jobTitle: (us.child('jobTitle').val() ?? '').toString().trim(),
              jobCategory: (us.child('jobCategory').val() ?? '').toString().trim(),
              jobDescription: (us.child('jobDescription').val() ?? '').toString().trim(),
              jobLanguage: (us.child('jobLanguage').val() ?? '').toString().trim(),
              jobLocationName: (us.child('jobLocationName').val() ?? '').toString().trim(),
              jobCountry: (us.child('jobCountry').val() ?? '').toString().trim(),
              jobQualifications: (us.child('jobQualifications').val() ?? '').toString().trim(),
              jobTags: (us.child('jobTags').val() ?? '').toString().trim(),
              jobScheduleType: (us.child('jobScheduleType').val() ?? '').toString().trim(),
              workModel: (us.child('workModel').val() ?? '').toString().trim(),
              jobStartTime: (us.child('jobStartTime').val() ?? '').toString().trim(),
              jobEndTime: (us.child('jobEndTime').val() ?? '').toString().trim(),
              jobLocation: (us.child('jobLocation').val() ?? '').toString().trim(),
            };

            const titlePass    = fTitle        ? toKey(raw.jobTitle).includes(fTitle)                 : null;
            const categoryPass = fCategory     ? toKey(raw.jobCategory).includes(fCategory)           : null;
            const langPass     = fLanguage     ? toKey(raw.jobLanguage).includes(fLanguage)           : null;
            const qualPass     = fQualifications ? toKey(raw.jobQualifications).includes(fQualifications) : null;
            const tagsPass     = fTags         ? toKey(raw.jobTags).includes(fTags)                   : null;
            const locNamePass  = fLocationName ? toKey(raw.jobLocationName).includes(fLocationName)   : null;

            const oStart  = parseTimeToMins(raw.jobStartTime);
            const oEnd    = parseTimeToMins(raw.jobEndTime);
            const minPass = hasMin ? (!Number.isNaN(oStart) && oStart >= fMinStart) : null;
            const maxPass = hasMax ? (!Number.isNaN(oEnd)   && oEnd   <= fMaxEnd)   : null;

            const oSchedule = toKey(raw.jobScheduleType);
            const oWork     = toKey(raw.workModel);
            const schedPass = (fScheduleSet.size > 0) ? fScheduleSet.has(oSchedule) : null;
            const workPass  = (fWorkSet.size > 0)     ? fWorkSet.has(oWork)         : null;

            let distanceKm = null;
            let jobCoords  = null;

            const otherJobLoc = parseLatLng(raw.jobLocation);
            if (otherJobLoc) {
                jobCoords = otherJobLoc;
                if (myLoc) {
                    const d = getHaversineDistanceKmFrom2LatLngPoints(myLoc, otherJobLoc);
                    if (Number.isFinite(d)) distanceKm = d;
                }
            }

            const okDist = hasDist
            ? (otherJobLoc && Number.isFinite(distanceKm) && distanceKm <= maxKm)
            : true;
            if (okDist && otherJobLoc) {
                distanceKm = getHaversineDistanceKmFrom2LatLngPoints(myLoc, otherJobLoc);
            }
            
            if (otherJobLoc) jobCoords = otherJobLoc;

            // samo kriterijume koji nisu prazni uracunaj u min br. zadovoljenih kriterijuma
            const flags = [
            titlePass, categoryPass, langPass, qualPass, tagsPass, locNamePass,
            minPass, maxPass, schedPass, workPass,
            ].filter(v => v !== null);

            const passed = flags.filter(Boolean).length;
            const participates = flags.length;

            if (participates >= required && passed >= required && raw.jobTitle) {
            acc.push({
                uid: child.key,
                userSettings: raw,
                distanceKm,
                jobCoords,
                _matchCount: passed,
                _matchOf: participates,
            });
            }
          });

          setCards(acc);
          setIndex(0);
        } catch (e) {
          console.log('HomeScreen error:', e);
        } finally {
          setLoading(false);
        }
      },
      (err) => {
        console.log('HomeScreen error:', err?.code, err?.message);
        setLoading(false);
      }
    );

    return () => unsub();
  }, [userId]);

  if (!userId) return null;

  return (
    <View style={homeScreenStyles.container}>
      <Text style={homeScreenStyles.header}>Jobs that fit your criteria:</Text>

      {loading ? (
        <ActivityIndicator size="large" style={{ marginTop: 16 }} />
      ) : needsMore ? (
        <Text style={homeScreenStyles.hint}>Set at least {requiredN} matching criteria to see cards.</Text>
      ) : cards.length === 0 ? (
        <Text style={homeScreenStyles.hint}>No matching jobs for your matching settings yet.</Text>
      ) : (
        <FlatList
          ref={listRef}
          horizontal
          pagingEnabled
          data={cards}
          keyExtractor={(it) => it.uid}
          showsHorizontalScrollIndicator={false}
          onMomentumScrollEnd={(e) => {
            const i = Math.round(e.nativeEvent.contentOffset.x / width);
            setIndex(i);
          }}
          renderItem={({ item }) => (
            <View style={homeScreenStyles.page}>
              <View {...pan.panHandlers} style={homeScreenStyles.card}>
                
                {typeof item.distanceKm === 'number' && Number.isFinite(item.distanceKm) && (
                  <Text style={homeScreenStyles.line}>
                    <Label>Distance:</Label> {item.distanceKm.toFixed(1)} km
                  </Text>
                )}

                {renderLine('Title', item.userSettings.jobTitle)}
                {renderLine('Category', item.userSettings.jobCategory)}
                {renderLine('Description', item.userSettings.jobDescription)}
                {renderLine('Qualifications', item.userSettings.jobQualifications)}
                {renderLine('Language', item.userSettings.jobLanguage)}
                
                {renderLine('Schedule', item.userSettings.jobScheduleType)}
                {renderLine('Work model', item.userSettings.workModel)}
                {renderTimeLine(item.userSettings)}

                {renderLine('Tags', item.userSettings.jobTags)}
                
                {renderLine('Country', item.userSettings.jobCountry)}
                {renderLine('Location', item.userSettings.jobLocationName)}
                
                {item.jobCoords && (
                  <Pressable
                    style={homeScreenStyles.mapBtn}
                    onPress={() =>
                      navigation.navigate(
                        'MapPicker',
                        {
                          initialLocation: { lat: item.jobCoords.lat, lng: item.jobCoords.lng },
                          readOnly: true,
                          title: item.userSettings.jobLocationName || 'Job location',
                        }
                      )
                    }
                    hitSlop={8}
                  >
                    <Text style={homeScreenStyles.mapBtnText}>View on map</Text>
                  </Pressable>
                )}
              </View>
            </View>
          )}
        />
      )}

      {cards.length > 0 && (
        <Text style={homeScreenStyles.counter}>
          {index + 1}/{cards.length}
        </Text>
      )}
    </View>
  );
}
