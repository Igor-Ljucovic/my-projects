import { useEffect, useLayoutEffect, useRef, useState } from 'react';
import { View, StyleSheet } from 'react-native';
import MapView, { Marker } from 'react-native-maps';
import IconButton from '../components/UI/IconButton';
import * as Location from 'expo-location';

export default function MapPickerScreen({ navigation, route }) {
  const mapRef = useRef(null);
  const readOnly = !!route.params?.readOnly;
  const customTitle = route.params?.title;
  const target = route.params?.target; // npr. 'jobLocation' ili 'userLocation', mora 
  // kada imamo 2 ili vise lokacija na 1 stranici

  const [region, setRegion] = useState({
    latitude: 44.7866,
    longitude: 20.4489,
    latitudeDelta: 0.05,
    longitudeDelta: 0.05,
  });
  const [picked, setPicked] = useState(null);

  useLayoutEffect(() => {
    if (customTitle) {
      navigation.setOptions({ title: customTitle });
    }
  }, [navigation, customTitle]);

  useLayoutEffect(() => {
    if (readOnly) {
      navigation.setOptions({ headerRight: undefined });
    } else {
      navigation.setOptions({
        headerRight: () => (
          <IconButton
            icon="save"
            size={24}
            color="#fff"
            onPress={() => {
              if (!picked) return;

              navigation.navigate({
                name: route.params?.returnTo || 'UserSettings',
                params: {
                  pickedLocation: {
                    lat: picked.latitude,
                    lng: picked.longitude,
                  },
                  target,
                },
                merge: true,
              });
            }}
          />
        ),
      });
    }
  }, [navigation, readOnly, picked, route.params, target]);

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
      return;
    }

    const getCurrent = async () => {
      try {
        if (readOnly) return;
        const { status } = await Location.requestForegroundPermissionsAsync();
        if (status !== 'granted') return;
        const loc = await Location.getCurrentPositionAsync({});
        const nextRegion = {
          latitude: loc.coords.latitude,
          longitude: loc.coords.longitude,
          latitudeDelta: 0.05,
          longitudeDelta: 0.05,
        };
        setRegion(nextRegion);
        mapRef.current?.animateToRegion(nextRegion, 600);
      } catch {}
    };
    getCurrent();
  }, [route.params, readOnly]);

  const handleMapLongPress = (e) => {
    if (readOnly) return;
    const { latitude, longitude } = e.nativeEvent.coordinate;
    setPicked({ latitude, longitude });
  };

  return (
    <View style={styles.container}>
      <MapView
        ref={mapRef}
        style={styles.map}
        initialRegion={region}
        region={region}
        onRegionChangeComplete={setRegion}
        onLongPress={handleMapLongPress}
        scrollEnabled={true}
        zoomEnabled={true}
        rotateEnabled={true}
        pitchEnabled={true}
      >
        {picked && (
          <Marker
            coordinate={picked}
            title={customTitle || 'Location'}
            draggable={!readOnly}
            onDragEnd={(e) => {
              const { latitude, longitude } = e.nativeEvent.coordinate;
              setPicked({ latitude, longitude });
            }}
          />
        )}
      </MapView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  map: { flex: 1 },
  badge: {
    position: 'absolute',
    top: 10,
    alignSelf: 'center',
    backgroundColor: 'rgba(0,0,0,0.6)',
    paddingHorizontal: 10,
    paddingVertical: 6,
    borderRadius: 12,
  },
  badgeText: { color: '#fff', fontWeight: '600' },
});
