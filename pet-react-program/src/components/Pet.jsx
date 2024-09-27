import React, { useState } from "react";

export default function Pet() {
    const [pets, setPets] = useState([]);
    const [stats, setStats] = useState({ male: 0, female: 0, total: 0, animalTypeCounts: {} });

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
        <div className="pet-container">
            <button onClick={() => generatePets(21)}>Generate 21 Pets</button>
            
            {pets.length > 0 && (
                <div className="pet-list">
                    {pets.map((pet) => (
                        <div key={pet.id} className="pet-details">
                            <h2>{pet.name}</h2>
                            <img src={pet.imageUrl} alt={pet.name} style={{ width: "150px", height: "150px", objectFit: "cover" }} />
                            <p>Age: {pet.age}</p>
                            <p>Gender: {pet.gender}</p>
                            <p>Owner: {pet.owner}</p>
                        </div>
                    ))}
                </div>
            )}

            <div>
                <p>Total Pets: {stats.total}</p>
                <p>Males: {stats.male}</p>
                <p>Females: {stats.female}</p>
                <h3>Animal Type Counts:</h3>
                <ul>
                    {Object.keys(stats.animalTypeCounts).map((type) => (
                        <li key={type}>
                            {type}: {stats.animalTypeCounts[type]}
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}
