import React from "react";

export default function Pet({ pets, stats, generatePets }) {  
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
