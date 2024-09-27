using PetApiProgram.Models;
using System;
using System.Collections.Generic;

namespace PetApiProgram.Services
{
    public class PetService
    {
        private readonly List<string> petNames = new List<string> { "Buddy", "Whiskers", "Fluffy", "Bella", "Max", "Luna", "Charlie", "Milo" };
        private readonly List<string> petImages = new List<string>
        {
            "https://localhost:7172/Images/orangeCat1.jpg\r\n", // Replace with your actual image URLs
            "https://localhost:7172/Images/orangeCat2.jpg\r\n",
            "https://localhost:7172/Images/smallDog1.jpg\r\n",
            "https://localhost:7172/Images/mediumDog1.jpeg\r\n"
        };
        private readonly List<string> owners = new List<string> { "Alice", "Bob", "Charlie", "Dave", "Eva" };
        private readonly List<string> genders = new List<string> { "Male", "Female" };

        // Single instance of Random for consistent random generation
        private readonly Random _random = new Random();

        public Pet GetRandomPet()
        {
            return new Pet
            {
                Id = Guid.NewGuid().ToString(),
                Name = petNames[_random.Next(petNames.Count)],
                ImageUrl = petImages[_random.Next(petImages.Count)],
                Age = _random.Next(1, 11), // Random age between 1 and 10
                Gender = genders[_random.Next(genders.Count)],
                Owner = owners[_random.Next(owners.Count)]
            };
        }

        public List<Pet> GenerateRandomPets(int number)
        {
            var pets = new List<Pet>();
            for (int i = 0; i < number; i++)
            {
                pets.Add(GetRandomPet());
            }
            return pets;
        }
    }
}
