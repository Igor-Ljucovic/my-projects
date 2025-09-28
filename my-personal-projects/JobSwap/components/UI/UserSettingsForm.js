import { ScrollView, View, Text, TextInput, Switch, KeyboardAvoidingView, Platform, Pressable } from 'react-native';
import CountryPicker, { Flag } from 'react-native-country-picker-modal';
import { Field, TimeInput, ScheduleToggle, WorkFromHomeToggle } from '../../util/userSettings';
import { userSettingsFormStyles } from '../../constants/styles';

export default function UserSettingsForm({ form, setText, setBool, setValue, setForm, isFixed, initialForPicker, navigation, handleSave, saving }) {
  
    return (
        <KeyboardAvoidingView
            behavior={Platform.select({ ios: 'padding', android: undefined })}
            style={{ flex: 1 }}
            keyboardVerticalOffset={Platform.select({ ios: 84, android: 0 })}
        >
        <ScrollView contentContainerStyle={userSettingsFormStyles.container}>
            <View style={userSettingsFormStyles.card}>
                <Text style={userSettingsFormStyles.sectionTitle}>Privacy & Notifications</Text>

                <View style={userSettingsFormStyles.row}>
                    <Text style={userSettingsFormStyles.rowLabel}>Public Profile</Text>
                    <Switch value={form.publicProfile} onValueChange={setBool('publicProfile')} />
                </View>

                <View style={userSettingsFormStyles.row}>
                    <Text style={userSettingsFormStyles.rowLabel}>Message Notifications</Text>
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
                        countryCode={form.jobCountry || undefined}
                        withFilter
                        withFlag
                        withCountryNameButton
                        withAlphaFilter
                        withEmoji
                        onSelect={(c) => {
                        // c.cca2 je naziv drzave u 2 slova, npr. RS (Serbia)
                        setForm((prev) => ({ ...prev, jobCountry: c.cca2 }));
                    }}
                    containerButtonStyle={{ flex: 1 }}
                    />
                </View>
                </View>
                {!!form.jobCountry && (
                <Text style={userSettingsFormStyles.helpText}>Selected: {form.jobCountry}</Text>
                )}
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
            <Text style={userSettingsFormStyles.sectionTitle}>Time & Flexibility</Text>

            <Field label="Schedule Type">
                <ScheduleToggle
                    value={form.jobScheduleType}
                    onChange={(val) => setValue('jobScheduleType', val)}
                />
            </Field>

            <Field label="Work From Home">
                <WorkFromHomeToggle
                    value={form.workFromHome}
                    onChange={(val) => setValue('workFromHome', val)}
                />
            </Field>

            <Field label="Start Time">
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

            <Field label="Location Name">
                <TextInput
                    value={form.jobLocationName}
                    onChangeText={setText('jobLocationName')}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., London"
                />
            </Field>

            <Field label="Location">
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
                    onPress={() =>
                        navigation.navigate('MapPicker', {
                        returnTo: 'UserSettings',
                        initialLocation: initialForPicker,
                    })
                }
                style={userSettingsFormStyles.mapPickButton}>
                <Text style={userSettingsFormStyles.mapPickButtonText}>Map</Text>
                </Pressable>
                <View style={{ flex: 1, justifyContent: 'center' }}>
                <Text style={userSettingsFormStyles.helpText}>Long-press the map to drop a pin</Text>
                </View>
            </View>
            </View>

            <View style={userSettingsFormStyles.buttonsRow}>
            <Pressable onPress={handleSave} style={userSettingsFormStyles.mapPickButton} disabled={saving}>
                <Text style={userSettingsFormStyles.mapPickButtonText}>Save</Text>
            </Pressable>
            </View>
        </ScrollView>
        </KeyboardAvoidingView>
    );
}