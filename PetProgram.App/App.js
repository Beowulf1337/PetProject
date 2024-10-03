import React, { useState } from 'react';
import { StyleSheet, View, Text, ScrollView } from 'react-native';
import AddPetForm from './AddPetForm';
import Pet from './Pet';


// define the app component which manages both the pet list and the stats
export default function App() {

    // state manages the list of pets
    const [pets, setPets] = useState([]);

    // state to manage stats
    const [stats, setStats] = useState({ male: 0, female: 0, total: 0, animalTypeCounts: {} });

    // state to manage a unique id for each pet
    const [idCounter, setIdCounter] = useState(1);

    // function to handle adding a new pet
    const handleAddPet = (newPet) => {

        // create a new pet object with a unique id
        const petWithId = { ...newPet, id: idCounter };

        // update the pets array with the new pets
        setPets((prevPets) => [...prevPets, petWithId]);

        // incriment the id counter for the next pet
        setIdCounter((prevCounter) => prevCounter + 1);

        // update stats after adding the new pet
        updateStats(newPet);
    };

    // function to update the stats based on the new pet added
    const updateStats = (newPet) => {
        setStats((prevStats) => {

            // update the total pet count 
            const updatedTotal = prevStats.total + 1;

            // incriment the male count if pet is male otherwise keep it the same
            const updatedMale = newPet.gender === 'Male' ? prevStats.male + 1 : prevStats.male;

            // incriment the male count if pet is female otherwise keep it the same
            const updatedFemale = newPet.gender === 'Female' ? prevStats.female + 1 : prevStats.female;

            // update the animal type count meaning for example how many dogs, cats, etc
            const updatedAnimalTypeCounts = {
                ...prevStats.animalTypeCounts,
                [newPet.animalType]: (prevStats.animalTypeCounts[newPet.animalType] || 0) + 1,
            };

            // return the updated stat total
            return {
                total: updatedTotal,
                male: updatedMale,
                female: updatedFemale,
                animalTypeCounts: updatedAnimalTypeCounts,
            };
        });
    };

    // function to fetch as set number of pets from the Api
    const generatePets = async (number) => {
        try {

            // make a request to the backend Api to generate pets
            const response = await fetch(`https://localhost:7172/api/pets/generate/${number}`);
            const fetchedPets = await response.json();

            // set the fetched pets in state 
            setPets(fetchedPets);

            // calculate stats based on fetched pets and update the stats
            const updatedStats = calculateStats(fetchedPets);
            setStats(updatedStats);
        } catch (error) {

            // Log any error that occurs during the API call
            console.error("Error fetching pets:", error);
        }
    };

    // function to calculate stats 
    const calculateStats = (pets) => {

        // calculate number of pets that are male
        const maleCount = pets.filter(pet => pet.gender === 'Male').length;

        // calculate number of pets that are female
        const femaleCount = pets.filter(pet => pet.gender === 'Female').length;

        // calculate how many pets of each type there are
        const animalTypeCounts = pets.reduce((acc, pet) => {
            acc[pet.animalType] = (acc[pet.animalType] || 0) + 1;
            return acc;
        }, {});

        // return an object with the calculated stats
        return {
            total: pets.length,
            male: maleCount,
            female: femaleCount,
            animalTypeCounts,
        };
    };

    return (

        // scrollable view to allow scrolling through the page content
        <ScrollView contentContainerStyle={styles.fullPageContent}>

            {/* header container to display app title and subtitle */}
            <View style={styles.headerContainer}>

                {/* app title */}
                <Text style={styles.header}>P.E.T</Text>

                {/* app subtitle */}
                <Text style={styles.subHeader}>Pets Extra Times</Text>
            </View>

            {/* main container to hold the statistics and form */}
            <View style={styles.mainContainer}>

                {/* stats container to display general statistics and animal type distribution */}
                <View style={styles.statsContainer}>
                    <View style={styles.generalAnimalStats}>

                        {/* general stats header */}
                        <Text style={styles.header}>Page statistics</Text>
                        <View style={styles.generalAnimalStatsActual}>

                            {/* display total number of pets aswell as male and female counts */}
                            <Text>Total Pets: {stats.total}</Text>
                            <Text>Males: {stats.male}</Text>
                            <Text>Females: {stats.female}</Text>
                        </View>
                    </View>

                    {/* container for displaying animal type distribution */}
                    <View style={styles.animalTypeStats}>

                        {/* animal type stats header */}
                        <Text style={styles.subHeader}>Pet type distribution</Text>
                        <View>

                            {/* map through animal types and display the count for each type */}
                            {Object.keys(stats.animalTypeCounts).map((type) => (
                                <Text key={type}>
                                    {type}: {stats.animalTypeCounts[type]}
                                </Text>
                            ))}
                        </View>
                    </View>
                </View>

                {/* container for the AddPetForm component which allows users to add new pets */}
                <View style={styles.centeredForm}>

                    {/* pass handleAddPet function to the form */}
                    <AddPetForm onAddPet={handleAddPet} />
                </View>
            </View>

            {/* pet component to display the list of pets and handle pet generation */}
            <Pet pets={pets} stats={stats} generatePets={generatePets} />
        </ScrollView>
    );
}

// styles for the page layout and components
const styles = StyleSheet.create({
    fullPageContent: {
        padding: 20,

        // align content to the left
        alignItems: 'flex-start',
    },
    mainContainer: {

        // arrange child components in a row
        flexDirection: 'row',
        justifyContent: 'flex-start',
        alignItems: 'flex-start',

        // take full width of the screen
        width: '100%',

        // max width of the container
        maxWidth: 1200,
        paddingHorizontal: 10,
    },
    statsContainer: {
        flex: 1,

        // limit the width of the stats container
        maxWidth: '35%',
        alignItems: 'flex-start',
        paddingRight: 10,
    },
    centeredForm: {
        flex: 1,

        // limit the width of the form container
        maxWidth: '50%',
        alignItems: 'center',
        marginLeft: 10,
    },
    generalAnimalStats: {
        marginBottom: 10,
        padding: 10,
        borderRadius: 5,

        // light gray background
        backgroundColor: '#f0f0f0',
        maxWidth: 300,
    },
    generalAnimalStatsActual: {
        padding: 5,
        borderRadius: 5,
    },
    animalTypeStats: {
        marginBottom: 10,
        padding: 10,
        borderRadius: 5,

        // light gray background
        backgroundColor: '#f0f0f0',
        maxWidth: 300,
    },
    headerContainer: {
        width: '100%',

        // center the content horizontally
        alignItems: 'center',
        marginBottom: 20,
    },
    header: {
        fontSize: 20,
        marginBottom: 5,

        // center the text
        textAlign: 'center',
    },
    subHeader: {
        fontSize: 18,
        marginBottom: 5,

        //  enter the text
        textAlign: 'center',
    },
});
