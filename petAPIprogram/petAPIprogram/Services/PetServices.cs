using PetApiProgram.Models;
using System;
using System.Collections.Generic;

namespace PetApiProgram.Services
{
    public class PetService
    {
      
        private readonly List<string> animalTypes = new List<string> { "Cat", "Dog", "Bird" };

     
        private readonly Dictionary<string, List<string>> petNames = new Dictionary<string, List<string>>
        {
            { "Cat", new List<string> { "Whiskers", "Fluffy", "Bella", "Luna" } },
            { "Dog", new List<string> { "Buddy", "Max", "Charlie", "Milo" } },
            { "Bird", new List<string> { "Tweety", "Sky", "Sunny", "Rio" } }
        };

        private readonly Dictionary<string, List<string>> petImages = new Dictionary<string, List<string>>
        {
            { "Cat", new List<string> { "https://localhost:7172/Images/orangeCat1.jpg", "https://localhost:7172/Images/orangeCat2.jpg" } },
            { "Dog", new List<string> { "https://localhost:7172/Images/smallDog1.jpg", "https://localhost:7172/Images/mediumDog1.jpeg" } },
            { "Bird", new List<string> { "https://localhost:7172/Images/birdParrot1.jpg", "https://localhost:7172/Images/birdParrot2.jpg" } }
        };

        private readonly Dictionary<string, List<int>> petAgeRanges = new Dictionary<string, List<int>>
        {
            { "Cat", new List<int> { 1, 20 } }, 
            { "Dog", new List<int> { 1, 15 } },
            { "Bird", new List<int> { 1, 10 } } 
        };

        private readonly List<string> owners = new List<string> { "Alice", "Bob", "Charlie", "Dave", "Eva" };
        private readonly List<string> genders = new List<string> { "Male", "Female" };

        private readonly Random random = new Random();

       

        public Pet GetRandomPet()
        {
            string animalType = animalTypes[random.Next(animalTypes.Count)];
            return GenerateSpecificPet(animalType);
        }

        private Pet GenerateSpecificPet(string animalType)
        {
            var name = petNames[animalType][random.Next(petNames[animalType].Count)];
            var imageUrl = petImages[animalType][random.Next(petImages[animalType].Count)];
            var ageRange = petAgeRanges[animalType];
            var age = random.Next(ageRange[0], ageRange[1] + 1);

            return new Pet
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                ImageUrl = imageUrl,
                Age = age,
                Gender = genders[random.Next(genders.Count)],
                Owner = owners[random.Next(owners.Count)]
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
