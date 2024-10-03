import React, { useEffect } from "react";

// Define the Pet component, which receives pets, stats, and a function to generate pets as props
export default function Pet({ pets, stats, generatePets }) {

    // useEffect hook to run when the component reloads
    useEffect(() => {

        // generate a random number between 20 and 30
        const numberOfPets = Math.floor(Math.random() * 11) + 20;

        // call the generatePets function with the random number of pets
        generatePets(numberOfPets); 

    // only run this effect once per page load
    }, []); 

    return (

        /* main container for the pet section */
        <div className="pet-container">

            {/* container for general statistics */}
            <div className="general-animal-stats">

                {/* title for the statistics section */}
                <h2>Page statistics</h2>

                {/* actual stats display */}
                <div className="general-animal-stats-actual">
                    <li>

                        {/* total number of pets */}
                        Total Pets: {stats.total} <br />

                        {/* total of male pets */}
                        Males: {stats.male} <br />

                        {/* total of female pets */}
                        Females: {stats.female} <br />
                    </li>
                </div>
            </div>

             {/* container for animal type distribution */}
            <div className="animal-type-stats">

                {/* title for the type distribution section */}
                <h3>Pet type distribution</h3>
                <ul>

                    {/* map over animal types*/}
                    {Object.keys(stats.animalTypeCounts).map((type) => (

                        /* each type as a list item */
                        <li key={type}>

                            {/* Display type and count */}
                            {type}: {stats.animalTypeCounts[type]}
                        </li>
                    ))}
                </ul>
            </div>

            {/* check if there are any pets to display*/}
            {pets.length > 0 && (

                /* container for the list of pets */
                <div className="pet-list">

                    {/*map over each pet to display details*/}
                    {pets.map((pet) => (

                        /* Eech pets details as a separate div */
                        <div key={pet.id} className="pet-details">

                            {/* pets name */}
                            <h2>{pet.name}</h2>

                            {/* pets image */}
                            <img src={pet.imageUrl} alt={pet.name} />

                            {/* pets age */}
                            <p>Age: {pet.age}</p>

                            {/* Pet's gender */}
                            <p>Gender: {pet.gender}</p>

                            {/* type of animal */}
                            <p>Animal Type: {pet.animalType}</p>

                            {/* pets owners name */}
                            <p>Owner: {pet.owner}</p>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
}
