import React, { useEffect } from "react";
import { View, Text, Image, ScrollView, StyleSheet } from "react-native";

export default function Pet({ pets, stats, generatePets }) {
    useEffect(() => {
        const numberOfPets = Math.floor(Math.random() * 11) + 20;
        generatePets(numberOfPets);
    }, []);

    return (
        <ScrollView contentContainerStyle={styles.container}>
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