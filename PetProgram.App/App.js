import React, { useState } from 'react';
import { StyleSheet, View, Text, ScrollView } from 'react-native';
import AddPetForm from './AddPetForm';
import Pet from './Pet';

export default function App() {
  const [pets, setPets] = useState([]);
  const [stats, setStats] = useState({ male: 0, female: 0, total: 0, animalTypeCounts: {} });
  const [idCounter, setIdCounter] = useState(1);

  const handleAddPet = (newPet) => {
    const petWithId = { ...newPet, id: idCounter };
    setPets((prevPets) => [...prevPets, petWithId]);
    setIdCounter((prevCounter) => prevCounter + 1);
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
    <ScrollView contentContainerStyle={styles.fullPageContent}>
      <Text style={styles.header}>P.E.T</Text>
      <Text style={styles.subHeader}>Pets Extra Times</Text>
      <AddPetForm onAddPet={handleAddPet} />
      <Pet pets={pets} stats={stats} generatePets={generatePets} />
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  fullPageContent: {
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
    padding: 20,
    textAlign: 'center',
    minHeight: '100%',
  },
  header: {
    fontSize: 40,
    marginBottom: 10,
  },
  subHeader: {
    fontSize: 24,
    marginBottom: 20,
  },
});
