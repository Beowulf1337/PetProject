import nedladdningImage from './images/orangeCat1.jpg';

const petNames = ["Buddy", "Whiskers", "Fluffy", "Bella", "Max", "Luna", "Charlie", "Milo"];
const petImages = [
    nedladdningImage, // Add your other images here
    "src/images/orangeCat2.jpg",
    "src/images/smallDog1.jpg",
    "src/images/mediumDog1.jpeg"
];
const owners = ["Alice", "Bob", "Charlie", "Dave", "Eva"];
const genders = ["Male", "Female"];

export const getRandomPet = () => {
    const name = petNames[Math.floor(Math.random() * petNames.length)];
    const imageUrl = petImages[Math.floor(Math.random() * petImages.length)];
    const age = Math.floor(Math.random() * 10) + 1; // Random age between 1 and 10
    const gender = genders[Math.floor(Math.random() * genders.length)];
    const owner = owners[Math.floor(Math.random() * owners.length)];

    return {
        id: Math.random().toString(36).substring(2, 9), // Generate a random ID
        name,
        imageUrl,
        age,
        gender,
        owner
    };
};

export default { success: true };
