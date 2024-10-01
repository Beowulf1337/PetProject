import React, { useState } from 'react';
import './App.css';
import Pet from './components/Pet.jsx';
import AddPetForm from './components/AddPetForm.jsx';

function App() {
    const [pets, setPets] = useState([]);
    const [stats, setStats] = useState({ male: 0, female: 0, total: 0, animalTypeCounts: {} });

    const handleAddPet = (newPet) => {
        setPets((prevPets) => [...prevPets, newPet]);
        updateStats(newPet);
    };

    const updateStats = (newPet) => {
        setStats((prevStats) => {
            const updatedTotal = prevStats.total + 1;
            const updatedMale = newPet.gender === 'Male' ? prevStats.male + 1 : prevStats.male;
            const updatedFemale = newPet.gender === 'Female' ? prevStats.female + 1 : prevStats.female;

            const updatedAnimalTypeCounts = {
                ...prevStats.animalTypeCounts,
                [newPet.animalType]: (prevStats.animalTypeCounts[newPet.animalType] || 0) + 1,
            };

            return {
                total: updatedTotal,
                male: updatedMale,
                female: updatedFemale,
                animalTypeCounts: updatedAnimalTypeCounts,
            };
        });
    };

    const generatePets = async (number) => {
        try {
            const response = await fetch(`https://localhost:7172/api/pets/generate/${number}`);
            const data = await response.json();
            setPets(data.pets);
            setStats(data.stats);
        } catch (error) {
            console.error("Error fetching pets:", error);
        }
    };
    return (
        <div className="full-page-content">
                <h1>P.E.T</h1>
                <h4>Pets Extra Times</h4>
            <AddPetForm onAddPet={handleAddPet} />
            <Pet pets={pets} stats={stats} generatePets={generatePets} />
        </div>
    );
}

export default App;
