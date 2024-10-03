import React, { useState } from 'react';
import { StyleSheet, Text, TextInput, View, Pressable } from 'react-native';
import {Picker} from '@react-native-picker/picker';


export default function AddPetForm({ onAddPet }) {
    const [name, setName] = useState('');
    const [age, setAge] = useState('');
    const [gender, setGender] = useState('Male');
    const [imageUrl, setImageUrl] = useState('');
    const [animalType, setAnimalType] = useState('Cat');
    const [owner, setOwner] = useState('');

    const handleSubmit = () => {
        if (!name || !age || !gender || !animalType || !owner) {
            alert("Please fill in all fields.");
            return;
        }
        const newPet = { name, age, gender, animalType, owner, imageUrl };
        onAddPet(newPet);
    };

    return (
        <View style={styles.formContainer}>
            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="Name"
                    value={name}
                    onChangeText={setName}
                />
            </View>

            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="Age"
                    value={age}
                    onChangeText={(value) => setAge(value.replace(/[^0-9]/g, ''))}
                />
            </View>

            <View style={styles.formRow}>
                <Picker
                    selectedValue={gender}
                    onValueChange={(itemValue) => setGender(itemValue)}
                >
                    <Picker.Item label="Male" value="Male" />
                    <Picker.Item label="Female" value="Female" />
                </Picker>
            </View>

            <View style={styles.formRow}>
                <Picker
                    selectedValue={animalType}
                    onValueChange={(itemValue) => setAnimalType(itemValue)}
                >
                    <Picker.Item label="Cat" value="Cat" />
                    <Picker.Item label="Dog" value="Dog" />
                    <Picker.Item label="Bird" value="Bird" />
                    <Picker.Item label="Horse" value="Horse" />
                    <Picker.Item label="Turtle" value="Turtle" />
                </Picker>
            </View>

            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="Owner"
                    value={owner}
                    onChangeText={setOwner}
                />
            </View>
            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="ImageUrl"
                    value={imageUrl}
                    onChangeText={setImageUrl}
                />
            </View>
            <Pressable onPress={handleSubmit} style={styles.addPetSubmit}>
                <Text>Add pet</Text>
            </Pressable>
        </View>
    );
}

const styles = StyleSheet.create({
    formContainer: {
        flexDirection: 'column',
        padding: 20,
        width: '100%',
        maxWidth: 600,
        margin: 'auto',
    },
    heading: {
        fontSize: 20,
        marginBottom: 20,
        textAlign: 'center',
    },
    formRow: {
        marginBottom: 15,
    },
    input: {
        width: '100%',
        padding: 10,
        fontSize: 16,
        borderWidth: 1,
        borderColor: '#ccc',
        borderRadius: 5,
    },
    addPetSubmit: {
        borderWidth: 1,
        borderColor: '#ccc',
        width: '100%',
        maxWidth: 55,
        borderRadius: 5,
    }
});
