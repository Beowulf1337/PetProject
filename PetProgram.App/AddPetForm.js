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
        setName('');
        setGender('Male');
        setAnimalType('Cat');
        setImageUrl('');
        setAge('Animals age');
        setOwner('')
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
                    placeholder="Animals age"
                    value={age}

                    // ensure age is a number
                    onChangeText={(value) => setAge(value.replace(/[^0-9]/g, ''))}
                />
            </View>

            {/* picker dropdown for selecting pet's gender */}  
            <View style={styles.formRow}>
                <Picker

                    // current selected value for gender
                    selectedValue={gender}

                    style={styles.picker}
                    
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
                <View style={styles.pickerWrapper}>
                <Picker

                    // current selected value for animal type
                    selectedValue={animalType}

                    style={styles.picker}

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

const styles = StyleSheet.create({
    formContainer: {

        // arrange child components in a vertical column
        flexDirection: 'column',

        // add padding inside the container
        padding: 20,

        // set the width to 100% of the parent container
        width: '100%',

        // limit the maximum width to 400 pixels
        maxWidth: 400,

        // center the container horizontally
        margin: 'auto',
    },
    formRow: {

        // add space below each form row to separate fields
        marginBottom: 15,
    },
    input: {

        // make the input field take the full width of its container
        width: '100%',

        // add padding inside the input field
        padding: 10,

        // set the font size for the input text
        fontSize: 16,

        // define the border width for the input field
        borderWidth: 1,

        // set the border color to light gray
        borderColor: '#ccc',

        // round the corners of the input field
        borderRadius: 5,
    },
    pickerWrapper: {

        // make the picker wrapper take the full width of its container
        width: '100%',

        // no padding inside the picker wrapper
        padding: 0,

        // define the border width for the picker wrapper
        borderWidth: 1,

        // set the border color to light gray
        borderColor: '#ccc',

        // round the corners of the picker wrapper
        borderRadius: 5,
    },
    picker: {

        // set the height of the Picker component
        height: 45,  

        // set the font size for the Picker text
        fontSize: 16,
    },
    addPetSubmit: {

        // define the border width for the submit button
        borderWidth: 1,

        // set the border color to light gray
        borderColor: '#ccc',

        // set the width of the button to 50% of its container
        width: '50%',  

        // round the corners of the button
        borderRadius: 5,

        // center the button horizontally within its parent
        alignSelf: 'center',  

        // add padding inside the button
        padding: 10,

        // center the text vertically within the button
        justifyContent: 'center', 
        
        // center the text horizontally within the button
        alignItems: 'center',  
    },
});
