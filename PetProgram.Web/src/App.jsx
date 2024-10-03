import React, { useState } from 'react';
import './index.css';
import Pet from './components/Pet.jsx';
import AddPetForm from './components/AddPetForm.jsx';

// define the main app component
function App() {

    // State to hold the list of pets
    const [pets, setPets] = useState([]);

    // State to hold statistics related to pets
    const [stats, setStats] = useState({ male: 0, female: 0, total: 0, animalTypeCounts: {} });

    // function to handle adding a new pet
    const handleAddPet = (newPet) => {

        // update the pets state with the new pet 
        setPets((prevPets) => [...prevPets, newPet]);

        // update stats with the new pets data
        updateStats(newPet);
    };

    // function to update stats based on the newly added pet
    const updateStats = (newPet) => {
        setStats((prevStats) => {

            // calculate the updated total amount of pets
            const updatedTotal = prevStats.total + 1;

            //  update the male count if the pet is male
            const updatedMale = newPet.gender === 'Male' ? prevStats.male + 1 : prevStats.male;

            //  update the male count if the pet is female
            const updatedFemale = newPet.gender === 'Female' ? prevStats.female + 1 : prevStats.female;

            // update the animal type counts by adding 1  to the new pets animal type
            const updatedAnimalTypeCounts = {
                ...prevStats.animalTypeCounts,
                [newPet.animalType]: (prevStats.animalTypeCounts[newPet.animalType] || 0) + 1,
            };

            // return the updated stats
            return {
                total: updatedTotal,
                male: updatedMale,
                female: updatedFemale,
                animalTypeCounts: updatedAnimalTypeCounts,
            };
        });
    };

    // function to generate a specifikc number of pets from the Api
    const generatePets = async (number) => {
        try {

            // fetch pets from the backend Api
            const response = await fetch(`https://localhost:7172/api/pets/generate/${number}`);

            // parse with JSON response
            const fetchedPets = await response.json();

            // update the fetched pets with the fetched data
            setPets(fetchedPets);

            // calculate and then update the stats based on the newly added pets data
            const updatedStats = calculateStats(fetchedPets);
            setStats(updatedStats);
        } catch (error) {

            // log any errors that occured during the fetch
            console.error("Error fetching pets:", error);
        }
    };

    // function to calculate the stats based on the current list of pets
    const calculateStats = (pets) => {

        // count amount of male pets
        const maleCount = pets.filter(pet => pet.gender === 'Male').length;

        // count amount of female pets
        const femaleCount = pets.filter(pet => pet.gender === 'Female').length;

        // create an object to count the number of each type of animal 
        const animalTypeCounts = pets.reduce((acc, pet) => {

            // add to the count of the pets type
            acc[pet.animalType] = (acc[pet.animalType] || 0) + 1;
            return acc;
        }, {});

        // return an object which contain the total number of pets and the amount total amount of males, females and types
        return {
            total: pets.length,
            male: maleCount,
            female: femaleCount,
            animalTypeCounts,
        };
    };

    // render the main application UI
    return (
        <div className="full-page-content">
            <h1>P.E.T</h1>
            <h4>Pets Extra Times</h4>
            <AddPetForm onAddPet={handleAddPet} />
            <Pet pets={pets} stats={stats} generatePets={generatePets} />
        </div>
    );
}

// export the App component for use in other parts of the application
export default App;
