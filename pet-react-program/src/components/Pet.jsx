import React, { useState } from "react";
import { getRandomPet } from "../petsData"; // Adjust the import accordingly

export default function Pet() {
    const [pets, setPets] = useState([]);
    const [stats, setStats] = useState({ male: 0, female: 0, total: 0 });

    // Function to generate random pets
    const generatePets = async (number) => {
        const response = await fetch(`https://localhost:7172/api/pets/generate/${number}`);
        const data = await response.json();
        setPets(data.pets);
        setStats(data.stats);
    };
    

    return (
        <div className="pet-container">
            <button onClick={() => generatePets(21)}>Generate 21 Pets</button>
            {pets.length > 0 && (
                <div className="pet-list">
                    {pets.map((pet, index) => (
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
            </div>
        </div>
    );
}
