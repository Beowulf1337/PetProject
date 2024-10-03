import React, { useEffect } from "react";
import { View, Text, Image, ScrollView, StyleSheet } from "react-native";

export default function Pet({ pets, stats, generatePets }) {
    useEffect(() => {
        const numberOfPets = Math.floor(Math.random() * 11) + 20;
        generatePets(numberOfPets);
    }, []);

    return (
        <ScrollView contentContainerStyle={styles.container}>
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

            {pets.length > 0 && (
                <View style={styles.petList}>
                    {pets.map((pet) => (
                        <View key={pet.id} style={styles.petDetails}>
                            <Text style={styles.petName}>{pet.name}</Text>
                            <Image source={{ uri: pet.imageUrl }} style={styles.petImage} />
                            <Text>Age: {pet.age}</Text>
                            <Text>Gender: {pet.gender}</Text>
                            <Text>Animal Type: {pet.animalType}</Text>
                            <Text>Owner: {pet.owner}</Text>
                        </View>
                    ))}
                </View>
            )}
        </ScrollView>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: 20,
    },
    generalAnimalStats: {
        marginBottom: 10,
        padding: 10,
        borderRadius: 5,
        backgroundColor: '#f0f0f0',
        maxWidth: 300,
        alignSelf: 'flex-start',
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
        alignSelf: 'flex-start',
    },
    petList: {
        flexDirection: 'row',
        flexWrap: 'wrap',
        justifyContent: 'center',
        overflow: 'visible',
    },
    petDetails: {
        margin: 10,
        padding: 10,
        borderWidth: 1,
        borderColor: '#ccc',
        borderRadius: 8,
        textAlign: 'center',
    },
    petImage: {
        width: 150,
        height: 150,
        borderRadius: 8,
        objectFit: 'cover',
    },
});