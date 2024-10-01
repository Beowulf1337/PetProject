import React from "react";

export default function Pet({ pets, stats, generatePets }) {
    return (
        <div className="pet-container">
                <div className="general-animal-stats">
                <h2>Page statistics</h2>
                <div className="general-animal-stats-actual">
                    <li>
                    Total Pets: {stats.total} <br />
                    Males: {stats.male} <br />
                    Females: {stats.female} <br />
                    </li>
                </div>
                </div>
                <div className="animal-type-stats">
                <h3>Pet type distrubution</h3>
                <ul>
                    {Object.keys(stats.animalTypeCounts).map((type) => (
                        <li key={type}>
                            {type}: {stats.animalTypeCounts[type]}
                        </li>
                    ))}
                </ul>
            </div>
                <button onClick={() => generatePets(21)}>Generate 21 Pets</button>
            {pets.length > 0 && (
                <div className="pet-list">
                    {pets.map((pet) => (
                        <div key={pet.id} className="pet-details">
                            <h2>{pet.name}</h2>
                            <img
                                src={pet.imageUrl}
                                alt={pet.name}
                            />
                            <p>Age: {pet.age}</p>
                            <p>Gender: {pet.gender}</p>
                            <p>Animal Type: {pet.animalType}</p>
                            <p>Owner: {pet.owner}</p>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
}
