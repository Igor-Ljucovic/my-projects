import { useEffect, useRef, useState } from 'react';
import { View, Text, StyleSheet, Alert } from 'react-native';
import MapView, { Marker } from 'react-native-maps';
import * as Location from 'expo-location';
import IconButton from '../components/UI/IconButton';

export default function MapPickerScreen({ navigation, route }) {
  const mapRef = useRef(null);
  const [region, setRegion] = useState({
    latitude: 44.7866,
    longitude: 20.4489,
    latitudeDelta: 0.05,
    longitudeDelta: 0.05,
  });
  const [picked, setPicked] = useState(null);

  useEffect(() => {
    const init = route.params?.initialLocation;
    if (init?.lat && init?.lng) {
        const nextRegion = {
        latitude: init.lat,
        longitude: init.lng,
        latitudeDelta: 0.02,
        longitudeDelta: 0.02,
        };
        setRegion(nextRegion);
        setPicked({ latitude: init.lat, longitude: init.lng });
        mapRef.current?.animateToRegion(nextRegion, 600);
    }
    }, [route.params?.initialLocation]);

  useEffect(() => {
    navigation.setOptions({
      title: 'Pick Location',
      headerRight: () => (
        <IconButton
          icon="save"
          color="white"
          size={22}
          onPress={handleConfirm}
        />
      ),
    });
  }, [navigation, picked]);

  async function locateMe() {
    try {
      const { status } = await Location.requestForegroundPermissionsAsync();
      if (status !== 'granted') {
        Alert.alert('Permission needed', 'Location permission is required to locate you.');
        return;
      }
      const pos = await Location.getCurrentPositionAsync({ accuracy: Location.Accuracy.Balanced });
      const { latitude, longitude } = pos.coords;
      const nextRegion = { latitude, longitude, latitudeDelta: 0.02, longitudeDelta: 0.02 };
      setRegion(nextRegion);
      mapRef.current?.animateToRegion(nextRegion, 600);
    } catch (e) {
      Alert.alert('Error', 'Could not fetch current location.');
    }
  }

  function handleLongPress(e) {
    const { latitude, longitude } = e.nativeEvent.coordinate;
    setPicked({ latitude, longitude });
  }

  async function handleConfirm() {
    if (!picked) {
      Alert.alert('Pick a point', 'Long-press on the map to drop a pin.');
      return;
    }

    let label = '';
    try {
      const res = await Location.reverseGeocodeAsync({
        latitude: picked.latitude,
        longitude: picked.longitude,
      });
      if (res?.length) {
        const r = res[0];
        label = [r.name, r.street, r.city || r.subregion, r.region, r.postalCode, r.country]
          .filter(Boolean)
          .join(', ');
      }
    } catch {
      // nista, bice prazan label samo ako ne uspe, iovako je zasad neiskoriscen
    }

    const target = route.params?.target;
    navigation.navigate({
      name: route.params?.returnTo,
      params: {
        pickedLocation: { lat: picked.latitude, lng: picked.longitude, label },
        target, // target je npr. 'jobLocation' ili 'userLocation'
      },
      merge: true,
    });
  }

  return (
    <View style={{ flex: 1 }}>
      <MapView
        ref={mapRef}
        style={StyleSheet.absoluteFill}
        initialRegion={region}
        onLongPress={handleLongPress}
      >
        {picked && (
          <Marker
            coordinate={picked}
            title="Selected location"
            draggable
            onDragEnd={(e) => setPicked(e.nativeEvent.coordinate)}
          />
        )}
      </MapView>

      <View style={styles.fabRow}>
        <IconButton icon="locate" size={22} color="white" onPress={locateMe} style={styles.fab} />
        <IconButton icon="save" size={22} color="white" onPress={handleConfirm} style={styles.fab} />
      </View>

      {!picked && (
        <View style={styles.tip}>
          <Text style={styles.tipText}>Long-press anywhere to drop a pin.</Text>
        </View>
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  fabRow: {
    position: 'absolute',
    right: 12,
    bottom: 24,
    gap: 10,
    alignItems: 'flex-end',
  },
  fab: {
    backgroundColor: '#2563eb',
    borderRadius: 24,
    padding: 12,
  },
  tip: {
    position: 'absolute',
    left: 12,
    right: 12,
    bottom: 24 + 80,
    backgroundColor: 'rgba(0,0,0,0.6)',
    borderRadius: 10,
    padding: 10,
  },
  tipText: { color: 'white', textAlign: 'center' },
});
