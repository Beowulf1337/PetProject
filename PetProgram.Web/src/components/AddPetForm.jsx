    import React, { useState } from 'react';

    // define the AddPetForm component which gets the prop onAddPet to handle adding a new pet
    const AddPetForm = ({ onAddPet }) => {

        // define the state variables for the pets details

        // the pets id is set to 0 as default at the start
        const [id, setId] = useState ('0')

        // the name of the pet 
        const [name, setName] = useState('');

        // the gender of the pet which is set to male as default
        const [gender, setGender] = useState('Male');

        // the type of pet which is set to Cat as the default
        const [animalType, setAnimalType] = useState('Cat');

        // the url of the pet image
        const [imageUrl, setImageUrl] = useState('');

        // the age of the pet
        const [age, setAge] = useState('Animals age');

        // the owner of the pets name
        const [owner, setOwner] = useState('');

        // function to handle form submission
        const handleSubmit = async (e) => {

            // prevent the default form submission behavior
            e.preventDefault();

            // create a new pet with the current state values
            const newPet = {
                Id: id,
                name: name,
                gender: gender, 
                imageUrl: imageUrl,
                age: age,
                owner: owner,   
                animalType: animalType
            };

            // convert the nePet object into JSON format
            const data = JSON.stringify(newPet);
            
            // send a post request to the Api to add a new pet
            const response = await fetch('https://localhost:7172/api/pets', {

                // using http method
                method: 'POST',
                headers: {

                    // set the content type to JSON
                    'Content-Type': 'application/json',
                },

                // include the pet data in the request body
                body: data
            });

            // check if the response is successful
            if (response.ok) {
                // parse the response JSON
                const addedPet = await response.json();

                // call the onAddPet function to update the parent component
                onAddPet(addedPet); 

                // reset the form fields to their original values
                setName('');
                setGender('Male');
                setAnimalType('Cat');
                setImageUrl('');
                setAge('Animals age');
                setOwner('')
            } else {

                // log an error if the request fails
                console.error('Failed to add pet');
            }
        };

        // render the form for adding a pet
        return (
            <form className="add-pet-form" onSubmit={handleSubmit}>
                <div className="form-row">
                    <input 
                        type="text" 
                        placeholder="Owner" 
                        value={owner} 

                        // update the owner state on input change
                        onChange={(e) => setOwner(e.target.value)} 

                        // make this field required
                        required 
                    />
                    <input 
                        type="text" 
                        placeholder="Pet Name" 
                        value={name} 

                        // update the owner state on input change
                        onChange={(e) => setName(e.target.value)} 
                    
                        // make this field required
                        required 
                    />
                </div>
                <div className="form-row-selectors">
                    <select 
                        value={gender} 

                        // Update gender state on selection change
                        onChange={(e) => setGender(e.target.value)} 

                        // Make this field required
                        required
                    >
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                    </select>

                    {/* Submit button for the form */}
                    <button className="submit-button"type="submit">
                        <div className="image-button-container">
                            <img 
                                src="src\components\Images\transparentPawSubmitButtonCropped.png" 
                                alt="Add Pet"
                            />

                             {/* Button text */}
                            <span className="add-pet-text">Add Pet</span>
                        </div>
                    </button>
                    <select value={animalType} 

                        // Update animalType state on selection change
                        onChange={(e) => setAnimalType(e.target.value)} 

                        // Make this field required
                        required
                    >
                        <option value="Cat">Cat</option>
                        <option value="Dog">Dog</option>
                        <option value="Bird">Bird</option>
                        <option value="Horse">Horse</option>
                        <option value="Turtle">Turtle</option>
                    </select>
                </div>
                <div className="form-row">
                    <input 
                        type="number" 
                        placeholder="Animal Age" 
                        value={age} 

                        // Update age state on input change
                        onChange={(e) => setAge(Number(e.target.value))} 

                        // Make this field required
                        required 
                    />
                    <input 
                        type="text" 
                        placeholder="Image URL" 
                        value={imageUrl} 

                        // Update imageUrl state on input change
                        onChange={(e) => setImageUrl(e.target.value)} 

                        // Make this field required
                        required 
                    />
                </div>
            </form>
        );
    };

    // Export the AddPetForm component for use in other parts of the application
    export default AddPetForm;
