import { ScrollView, View, Text, TextInput, Pressable } from 'react-native';
import CountryPicker, { Flag } from 'react-native-country-picker-modal';
import { Field, TimeInput, ScheduleTypesToggleMatchingSettings, WorkModelsToggleMatchingSettings } from '../../util/settings';
import { userSettingsFormStyles } from '../../constants/styles';


export default function UserMatchingSettingsForm({ form, setText, setForm, handleSave, saving }) {
  
    return (
        <ScrollView contentContainerStyle={userSettingsFormStyles.container}>
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
            <Text style={userSettingsFormStyles.sectionTitle}>Time & Flexibility</Text>

            <Field label="Schedule Type(s)">
            <ScheduleTypesToggleMatchingSettings
                value={form.jobScheduleTypes || []}
                onChange={(updater) =>
                setForm(prev => ({
                    ...prev,
                    jobScheduleTypes:
                    typeof updater === 'function'
                        ? updater(prev.jobScheduleTypes || [])
                        : updater,
                }))
                }
            />
            </Field>


            <Field label="Work Arrangement(s)">
            <WorkModelsToggleMatchingSettings
                value={form.workModels || []}
                onChange={(updater) =>
                setForm(prev => ({
                    ...prev,
                    workModels:
                    typeof updater === 'function'
                        ? updater(prev.workModels || [])
                        : updater,
                }))
                }
            />
            </Field>

            <Field label="Earliest Start Time">
                <TimeInput
                    value={form.jobStartTime}
                    onChangeText={setText('jobStartTime')}
                />
            </Field>

            <Field label="Latest End Time">
                <TimeInput
                    value={form.jobEndTime}
                    onChangeText={setText('jobEndTime')}
                />
            </Field>
            </View>

            <View style={userSettingsFormStyles.card}>
            <Text style={userSettingsFormStyles.sectionTitle}>Location</Text>

            <Field label="Max location distance (km)">
                <TextInput
                    value={String(form.maxJobLocationDistanceKm ?? '')}
                    onChangeText={(txt) => {
                    const intVal = parseInt(txt.replace(/\D+/g, ''), 10);
                    setForm((prev) => ({
                        ...prev,
                        maxJobLocationDistanceKm: Number.isNaN(intVal) ? '' : intVal,
                    }));
                    }}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., 10"
                    keyboardType="numeric"
                />
            </Field>
            </View>

            <View style={userSettingsFormStyles.card}>
            <Text style={userSettingsFormStyles.sectionTitle}>General</Text>

            <Field label="Minimum number of criteria to match">
                <TextInput
                    value={String(form.minimumNumberOfCriteriaToMatch ?? '')}
                    onChangeText={(txt) => {
                    const intVal = parseInt(txt.replace(/\D+/g, ''), 10);
                    setForm((prev) => ({
                        ...prev,
                        minimumNumberOfCriteriaToMatch: Number.isNaN(intVal) ? '' : intVal,
                    }));
                    }}
                    style={userSettingsFormStyles.input}
                    placeholder="e.g., 1"
                    keyboardType="numeric"
                />
            </Field>
            </View>

            <View style={userSettingsFormStyles.buttonsRow}>
            <Pressable onPress={handleSave} style={userSettingsFormStyles.mapPickButton} disabled={saving}>
                <Text style={userSettingsFormStyles.mapPickButtonText}>Save</Text>
            </Pressable>
            </View>
        </ScrollView>
    );
}