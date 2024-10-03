import React, { useState } from 'react';
import { StyleSheet, Text, TextInput, View, Pressable } from 'react-native';
import {Picker} from '@react-native-picker/picker';

// define the AddPetForm which revieves the onAddPet function as a prop 
export default function AddPetForm({ onAddPet }) {

    // state variables to manage the form inputs

    // state for pet's name
    const [name, setName] = useState('');

    // state for pet's age
    const [age, setAge] = useState('');

    // state for pet's gender where the default is male
    const [gender, setGender] = useState('Male');

    // state for the pets image url
    const [imageUrl, setImageUrl] = useState('');

    // state for the pets type where the default is cat
    const [animalType, setAnimalType] = useState('Cat');

    // state for the pets owner name
    const [owner, setOwner] = useState('');

    // function to handle form submission
    const handleSubmit = () => {

        // validation that alerts the user if any field is empty
        if (!name || !age || !gender || !animalType || !owner) {
            alert("Please fill in all fields.");
            return;
        }

        // create a new pet with the current form values
        const newPet = { name, age, gender, animalType, owner, imageUrl };

        // call the onAddPet function passed as a prop passing the new pet data
        onAddPet(newPet);
    };

    return (

        // main container for the form
        <View style={styles.formContainer}>

            {/* input field for pet's name */}
            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="Name"
                    value={name}

                    // update name state on text change
                    onChangeText={setName}
                />
            </View>

            {/* input field for pet's age, allows only numeric values */}
            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="Age"
                    value={age}

                    // ensure age is a number
                    onChangeText={(value) => setAge(value.replace(/[^0-9]/g, ''))}
                />
            </View>

            {/* picker dropdown for selecting pet's gender */}  
            <View style={styles.formRow}>
                <Picker
                    selectedValue={gender}

                    // update gender on selection
                    onValueChange={(itemValue) => setGender(itemValue)}
                >
                    {/* option for Male */}
                    <Picker.Item label="Male" value="Male" />

                    {/* option for Female */}
                    <Picker.Item label="Female" value="Female" />
                </Picker>
            </View>

            {/* picker dropdown for selecting animal type */}
            <View style={styles.formRow}>
                <Picker
                    selectedValue={animalType}

                    // update animal type on selection
                    onValueChange={(itemValue) => setAnimalType(itemValue)}
                >
                    {/* different options for animal types */}
                    <Picker.Item label="Cat" value="Cat" />
                    <Picker.Item label="Dog" value="Dog" />
                    <Picker.Item label="Bird" value="Bird" />
                    <Picker.Item label="Horse" value="Horse" />
                    <Picker.Item label="Turtle" value="Turtle" />
                </Picker>
            </View>

            {/* input field for owner's name */}
            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="Owner"
                    value={owner}

                    // update owner state on text change
                    onChangeText={setOwner}
                />
            </View>

            {/* input field for pet's image URL */}
            <View style={styles.formRow}>
                <TextInput
                    style={styles.input}
                    placeholder="ImageUrl"
                    value={imageUrl}

                    // update imageUrl state on text change
                    onChangeText={setImageUrl}
                />
            </View>

            {/* button to submit the form */}
            <Pressable onPress={handleSubmit} style={styles.addPetSubmit}>
                <Text>Add pet</Text>
            </Pressable>
        </View>
    );
}

// styles for the form and its elements
const styles = StyleSheet.create({
    formContainer: {

        // arrange items in a column
        flexDirection: 'column',

        // add padding inside the container
        padding: 20,
        width: '100%',

        // limit max width
        maxWidth: 600,

        // center the form
        margin: 'auto',
    },
    heading: {

        // font size for heading
        fontSize: 20,

        // margin below the heading
        marginBottom: 20,

        // center the heading text
        textAlign: 'center',
    },
    formRow: {

        // space between form fields
        marginBottom: 15,
    },
    input: {

        // full width input fields
        width: '100%',

        // padding inside input fields
        padding: 10,

        // font size for input text
        fontSize: 16,

        // border width for input fields
        borderWidth: 1,

        // light gray border color
        borderColor: '#ccc',

        // rounded corners
        borderRadius: 5,
    },
    addPetSubmit: {

        // border width for the submit button
        borderWidth: 1,

        // border color
        borderColor: '#ccc',

        // full width submit button
        width: '100%',

        // limit width for submit button
        maxWidth: 55,

        // rounded corners for button
        borderRadius: 5,
    }
});
