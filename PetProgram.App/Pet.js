import React, { useEffect } from "react";
import { View, Text, Image, ScrollView, StyleSheet } from "react-native";

// define the pet component that displays the list of pets and their details
export default function Pet({ pets, stats, generatePets }) {

    // useEffect hook to generate a random number of pets when the component mounts
    useEffect(() => {

        // generate a random number of pets between 20 and 30
        const numberOfPets = Math.floor(Math.random() * 11) + 20;

        // call the generatePets function with the random number
        generatePets(numberOfPets);

    // only run this effect once per page load
    }, []);

    return (

        // scrollable view to display pet list
        <ScrollView contentContainerStyle={styles.container}>

            {/* render the pet list only if there are pets available */}
            {pets.length > 0 && (
                <View style={styles.petList}>

                    {/* map over the pets array and render each pet's details */}
                    {pets.map((pet) => (

                        /* unique key prop based on pet id */
                        <View key={pet.id} style={styles.petDetails}>

                            {/* display pet name */}
                            <Text style={styles.petName}>{pet.name}</Text>

                            {/* display pet image */}
                            <Image source={{ uri: pet.imageUrl }} style={styles.petImage} />

                            {/* display pet age */}
                            <Text>Age: {pet.age}</Text>

                            {/* display pet gender */}
                            <Text>Gender: {pet.gender}</Text>

                            {/* display pet's animal type */}
                            <Text>Animal Type: {pet.animalType}</Text>

                            {/* display pet owner */}
                            <Text>Owner: {pet.owner}</Text>
                        </View>
                    ))}
                </View>
            )}
        </ScrollView>
    );
}

// define styles for the Pet component
const styles = StyleSheet.create({
    container: {

        // take up the full height of the screen
        flex: 1,

        // add padding around the content
        padding: 20,
    },
    petList: {

        // display pets in a row
        flexDirection: 'row',

        // allow pets to wrap to the next line if they overflow
        flexWrap: 'wrap',

        // center the pets within the row
        justifyContent: 'center',

        // allow content to overflow beyond the container if needed
        overflow: 'visible',
    },
    petDetails: {

        // add margin around each pet card
        margin: 10,

        // add padding inside the pet card
        padding: 10,

        // add a border around the pet card
        borderWidth: 1,

        // set a light gray color for the border
        borderColor: '#ccc',

        // round the corners of the pet card
        borderRadius: 8,

        // center-align the text
        textAlign: 'center',
    },
    petImage: {

        // set a fixed width for the pet image
        width: 150,

        // set a fixed height for the pet image
        height: 150,

        // round the corners of the image
        borderRadius: 8,

        // ensure the image covers the entire area without distortion
        objectFit: 'cover',
    },
});