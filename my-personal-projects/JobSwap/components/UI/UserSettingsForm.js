import { ScrollView, View, Text, TextInput, Switch, Pressable } from 'react-native';
import CountryPicker, { Flag } from 'react-native-country-picker-modal';
import { Field, TimeInput, ScheduleTypeToggleUserSettings, WorkModelToggleUserSettings } from '../../util/settings';
import { userSettingsFormStyles } from '../../constants/styles';
import IconButton from '../UI/IconButton';

export default function UserSettingsForm({ form, setText, setBool, setValue, setForm, isFixed, initialForPicker, navigation, handleSave, saving, authCtx }) {
  
    return (
        <ScrollView contentContainerStyle={userSettingsFormStyles.container}>
            <View style={userSettingsFormStyles.card}>
                <Text style={userSettingsFormStyles.sectionTitle}>Privacy & Notifications</Text>

                <View style={userSettingsFormStyles.row}>
                    <Text style={userSettingsFormStyles.rowLabel}>Make my profile visible to others</Text>
                    <Switch value={form.publicProfile} onValueChange={setBool('publicProfile')} />
                </View>

                <View style={userSettingsFormStyles.row}>
                    <Text style={userSettingsFormStyles.rowLabel}>Send me message notifications</Text>
                    <Switch
                        value={form.getMessageNotifications}
                        onValueChange={setBool('getMessageNotifications')}
                    />
                </View>
            </View>

            <View style={userSettingsFormStyles.card}>
            <Text style={userSettingsFormStyles.sectionTitle}>Job Information</Text>

            <Field label="Job Category">
                <TextInput
                    value={form.jobCategory}
                    onChangeText={setText('jobCategory')}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., Sales"
                />
            </Field>

            <Field label="Job Title">
                <TextInput
                    value={form.jobTitle}
                    onChangeText={setText('jobTitle')}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., Supermarket cashier"
                />
            </Field>

            <Field label="Job Description">
                <TextInput
                    value={form.jobDescription}
                    onChangeText={setText('jobDescription')}
                    style={[userSettingsFormStyles.input, userSettingsFormStyles.textarea]}
                    multiline
                    placeholder="Describe your role"
                />
            </Field>

            <Field label="Job Qualifications">
                <TextInput
                    value={form.jobQualifications}
                    onChangeText={setText('jobQualifications')}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., None, BSc"
                />
            </Field>

            <Field label="Job Language">
                <TextInput
                    value={form.jobLanguage}
                    onChangeText={setText('jobLanguage')}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., English, Spanish"
                />
            </Field>

            <Field label="Job Country">
            <View style={[userSettingsFormStyles.input, { paddingVertical: 0, backgroundColor: '#F6F7F9' }]}>
                <View style={{ flexDirection: 'row', alignItems: 'center', paddingVertical: 10 }}>
                {form.jobCountry ? (
                    <View style={{ marginRight: 8 }}>
                    <Flag countryCode={form.jobCountry} />
                    </View>
                ) : null}

                <CountryPicker
                    key={`picker-${form.jobCountry || 'none'}`}
                    countryCode={form.jobCountry || undefined}
                    withFilter
                    withFlag
                    withCountryNameButton
                    withAlphaFilter
                    withEmoji
                    onSelect={(c) => {
                    setForm((prev) => ({ ...prev, jobCountry: c.cca2 }));
                    }}
                    containerButtonStyle={{ flex: 1 }}
                />

                {form.jobCountry ? (
                    <Pressable
                    onPress={() => setForm((prev) => ({ ...prev, jobCountry: '' }))}
                    hitSlop={12}
                    style={{
                        paddingHorizontal: 10,
                        paddingVertical: 4,
                        borderRadius: 999,
                        backgroundColor: '#e5e7eb',
                        marginLeft: 8,
                    }}
                    >
                    <Text style={{ fontSize: 12, color: '#374151' }}>Clear</Text>
                    </Pressable>
                ) : null}
                </View>
            </View>
            </Field>


            <Field label="Job Tags">
                <TextInput
                value={form.jobTags}
                onChangeText={setText('jobTags')}
                style={userSettingsFormStyles.input}
                placeholder="e.g., Cashier, Retail, Part-time, Weekend"
                autoCapitalize="none"
                />
            </Field>
            </View>

            <View style={userSettingsFormStyles.card}>
            <Text style={userSettingsFormStyles.sectionTitle}>Job Time & Flexibility</Text>

            <Field label="Job Schedule Type">
                <ScheduleTypeToggleUserSettings
                    value={form.jobScheduleType}
                    onChange={(val) => setValue('jobScheduleType', val)}
                />
            </Field>

            <Field label="Job Work Model">
                <WorkModelToggleUserSettings
                    value={form.workModel}
                    onChange={(val) => setValue('workModel', val)}
                />
            </Field>

            <Field label="Job Start Time">
                <TimeInput
                    value={form.jobStartTime}
                    onChangeText={setText('jobStartTime')}
                    editable={isFixed}
                />
            </Field>

            <Field label="End Time">
                <TimeInput
                    value={form.jobEndTime}
                    onChangeText={setText('jobEndTime')}
                    editable={isFixed}
                />
            </Field>
            </View>

            <View style={userSettingsFormStyles.card}>
            <Text style={userSettingsFormStyles.sectionTitle}>Location</Text>

            <Field label="Job Location Name">
                <TextInput
                    value={form.jobLocationName}
                    onChangeText={setText('jobLocationName')}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., London"
                />
            </Field>

            <Field label="Job Location">
                <View style={[userSettingsFormStyles.input, { backgroundColor: '#e5e7eb' }]}>
                <Text
                    style={{
                    fontSize: 16,
                    color: form.jobLocation ? '#374151' : '#9ca3af',
                    }}
                >
                    {form.jobLocation || 'Pick a location on the map'}
                </Text>
                </View>
            </Field>

            <View style={{ flexDirection: 'row', gap: 10, marginTop: 8 }}>
                <Pressable
                    onPress={() => {
                        navigation.navigate('MapPicker', {
                            initialLocation: initialForPicker,
                            readOnly: false,
                            title: 'Job location',
                            target: 'jobLocation',
                            returnTo: 'UserSettings',
                        });
                    }}
                    style={userSettingsFormStyles.mapPickButton}
                    >
                    <Text style={userSettingsFormStyles.mapPickButtonText}>Map</Text>
                </Pressable>
                <View style={{ flex: 1, justifyContent: 'center' }}>
                <Text style={userSettingsFormStyles.helpText}>(Long-press the map to drop a pin)</Text>
                </View>
            </View>

            <Field label="Your Location">
                <View style={[userSettingsFormStyles.input, { backgroundColor: '#e5e7eb' }]}>
                <Text
                    style={{
                    fontSize: 16,
                    color: form.userLocation ? '#374151' : '#9ca3af',
                    }}
                >
                    {form.userLocation || 'Pick your location on the map'}
                </Text>
                </View>
            </Field>

    <View style={{ flexDirection: 'row', gap: 10, marginTop: 8 }}>
    <Pressable
      onPress={() => {
        const initialUserLoc = (() => {
          const s = form.userLocation;
          if (!s || typeof s !== 'string') return null;
          const parts = s.split(',').map(t => t.trim());
          if (parts.length !== 2) return null;
          const lat = Number(parts[0]); const lng = Number(parts[1]);
          return (Number.isFinite(lat) && Number.isFinite(lng)) ? { lat, lng } : null;
        })();
        navigation.navigate('MapPicker', {
          initialLocation: initialUserLoc,
          readOnly: false,
          title: 'Your location',
          target: 'userLocation',
          returnTo: 'UserSettings',
        });
      }}
      style={userSettingsFormStyles.mapPickButton}
    >
      <Text style={userSettingsFormStyles.mapPickButtonText}>Map</Text>
    </Pressable>

    <View style={{ flex: 1, justifyContent: 'center' }}>
      <Text style={userSettingsFormStyles.helpText}>
        (Long-press the map to drop a pin)
      </Text>
    </View>
    </View>        
    </View>
    <View style={[userSettingsFormStyles.buttonsRow, { flexDirection: 'row', alignItems: 'center' }]}>
  
    <View style={{ flex: 1 }} />

    <View style={{ flex: 1, alignItems: 'center' }}>
        <Pressable onPress={handleSave} style={userSettingsFormStyles.mapPickButton} disabled={saving}>
        <Text style={userSettingsFormStyles.mapPickButtonText}>Save</Text>
        </Pressable>
    </View>

    <View style={{ flex: 1, alignItems: 'flex-end' }}>
        <Pressable onPress={authCtx.logout} style={[userSettingsFormStyles.logoutButton, { flexDirection: 'row', alignItems: 'center' }]}>
        <IconButton icon="exit" size={17.5} color="white" />
        <Text style={{ marginLeft: -2, color: 'white' }}>Logout</Text>
        </Pressable>
    </View>
    </View>
    </ScrollView>
    );
}
