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
      <View style={styles.headerContainer}>
        <Text style={styles.header}>P.E.T</Text>
        <Text style={styles.subHeader}>Pets Extra Times</Text>
      </View>

      <View style={styles.mainContainer}>
        <View style={styles.statsContainer}>
          <View style={styles.generalAnimalStats}>
            <Text style={styles.header}>Page statistics</Text>
            <View style={styles.generalAnimalStatsActual}>
              <Text>Total Pets: {stats.total}</Text>
              <Text>Males: {stats.male}</Text>
              <Text>Females: {stats.female}</Text>
            </View>
          </View>

          <View style={styles.animalTypeStats}>
            <Text style={styles.subHeader}>Pet type distribution</Text>
            <View>
              {Object.keys(stats.animalTypeCounts).map((type) => (
                <Text key={type}>
                  {type}: {stats.animalTypeCounts[type]}
                </Text>
              ))}
            </View>
          </View>
        </View>

        <View style={styles.centeredForm}>
          <AddPetForm onAddPet={handleAddPet} />
        </View>
      </View>

      <Pet pets={pets} stats={stats} generatePets={generatePets} />
    </ScrollView>
  );
}
const styles = StyleSheet.create({
  fullPageContent: {
    padding: 20,
    alignItems: 'flex-start',
  },
  mainContainer: {
    flexDirection: 'row',
    justifyContent: 'flex-start',
    alignItems: 'flex-start',
    width: '100%',
    maxWidth: 1200,
    paddingHorizontal: 10,
  },
  statsContainer: {
    flex: 1,
    maxWidth: '35%',
    alignItems: 'flex-start',
    paddingRight: 10,
  },
  centeredForm: {
    flex: 1,
    maxWidth: '50%',
    alignItems: 'center',
    marginLeft: 10,
  },
  generalAnimalStats: {
    marginBottom: 10,
    padding: 10,
    borderRadius: 5,
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
    backgroundColor: '#f0f0f0',
    maxWidth: 300,
  },

  headerContainer: {
    width: '100%',
    alignItems: 'center',
    marginBottom: 20,
  },
  header: {
    fontSize: 20,
    marginBottom: 5,
    textAlign: 'center',
  },
  subHeader: {
    fontSize: 18,
    marginBottom: 5,
    textAlign: 'center',
  },
});