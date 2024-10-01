import React, { useState } from 'react';

const AddPetForm = ({ onAddPet }) => {
    const [id, setId] = useState ('0')
    const [name, setName] = useState('');
    const [gender, setGender] = useState('Male');
    const [animalType, setAnimalType] = useState('Cat');
    const [imageUrl, setImageUrl] = useState('');
    const [age, setAge] = useState('Animals age');
    const [owner, setOwner] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const newPet = {
            Id: id,
            name: name,
            gender: gender, // Ensure the key matches with your backend model
            imageUrl: imageUrl,
            age: age,
            owner: owner, // Modify as per your logic
            animalType: animalType
        };
        const data = JSON.stringify(newPet);
        
        const response = await fetch('https://localhost:7172/api/pets', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: data
        });

        if (response.ok) {
            const addedPet = await response.json();
            onAddPet(addedPet); // Update parent component with the new pet
            // Reset the form fields
            setName('');
            setGender('Male');
            setAnimalType('Cat');
            setImageUrl('');
            setAge('Animals age');
            setOwner('')
        } else {
            console.error('Failed to add pet');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input type="text" placeholder="Owner" value={owner} onChange={(e) => setOwner(e.target.value)} required /> 
            <input type="text" placeholder="Pet name" value={name} onChange={(e) => setName(e.target.value)} required />
            <select value={gender} onChange={(e) => setGender(e.target.value)}>
                <option value="Male">Male</option>
                <option value="Female">Female</option>
            </select>
            <select value={animalType} onChange={(e) => setAnimalType(e.target.value)}>
                <option value="Cat">Cat</option>
                <option value="Dog">Dog</option>
                <option value="Bird">Bird</option>
                <option value="Horse">Horse</option>
                <option value="Turtle">Turtle</option>
            </select>
            <input type="text" placeholder="Image URL" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} required />
            <input type="number" placeholder="Animals age" value={age} onChange={(e) => setAge(Number(e.target.value))} required />

            <button type="submit">Add Pet</button>
        </form>
    );
};

export default AddPetForm;
