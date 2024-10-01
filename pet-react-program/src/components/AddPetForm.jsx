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
        <form className="add-pet-form" onSubmit={handleSubmit}>
            <div className="form-row">
                <input type="text" placeholder="Owner" value={owner} onChange={(e) => setOwner(e.target.value)} required />
                <input type="text" placeholder="Pet Name" value={name} onChange={(e) => setName(e.target.value)} required />
            </div>
            <div className="form-row-selectors">
                <select value={gender} onChange={(e) => setGender(e.target.value)} required>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select>
                <button className="submit-button"type="submit">
                    <div className="image-button-container">
                        <img src="src\components\Images\transparentPawSubmitButtonCropped.png" alt="Add Pet"/>
                        <span className="add-pet-text">Add Pet</span>
                    </div>
                </button>
                <select value={animalType} onChange={(e) => setAnimalType(e.target.value)} required>
                    <option value="Cat">Cat</option>
                    <option value="Dog">Dog</option>
                    <option value="Bird">Bird</option>
                    <option value="Horse">Horse</option>
                    <option value="Turtle">Turtle</option>
                </select>
            </div>
            <div className="form-row">
                <input type="number" placeholder="Animal Age" value={age} onChange={(e) => setAge(Number(e.target.value))} required />
                <input type="text" placeholder="Image URL" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} required />
            </div>
        </form>
    );
};

export default AddPetForm;
