using PetApiProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetApiProgram.Services
{
    public class PetService
    {
        private readonly List<string> animalTypes = new List<string> { "Cat", "Dog", "Bird", "Horse", "Turtle"};

        private readonly Dictionary<string, List<string>> petNames = new Dictionary<string, List<string>>
        {
            { "Cat", new List<string> { "Whiskers", "Fluffy", "Bella", "Luna" } },
            { "Dog", new List<string> { "Buddy", "Max", "Charlie", "Milo" } },
            { "Bird", new List<string> { "Tweety", "Sky", "Sunny", "Rio" } },
            {"Horse", new List<string> {"Pegasus", "Bucephalus", "Seabiscuit", "Comanche" } },
            { "Turtle", new List<string> { "Leonardo", "Donatello", "Michelangelo", "Raphael" }}
        };

        private readonly Dictionary<string, List<string>> petImages = new Dictionary<string, List<string>>
        {
            { "Cat", new List<string> { "https://localhost:7172/Images/orangeCat1.jpg", "https://localhost:7172/Images/orangeCat2.jpg", "https://localhost:7172/Images/beigeCat1.jpg" } },
            { "Dog", new List<string> { "https://localhost:7172/Images/smallDog1.jpg", "https://localhost:7172/Images/mediumDog1.jpeg" } },
            { "Bird", new List<string> { "https://localhost:7172/Images/birdParrot1.jpg", "https://localhost:7172/Images/birdParrot2.jpg" } },
            { "Horse", new List<string> { "https://localhost:7172/Images/whiteHorse1.jpg", "https://localhost:7172/Images/brownHorse1.jpg" } },
            { "Turtle", new List<string>{ "https://localhost:7172/Images/smallTurtle1.jpg", "https://localhost:7172/Images/seaTurtle1.jpg" } }
        };

        private readonly Dictionary<string, List<int>> petAgeRanges = new Dictionary<string, List<int>>
        {
            { "Cat", new List<int> { 1, 20 } },
            { "Dog", new List<int> { 1, 15 } },
            { "Bird", new List<int> { 1, 10 } },
            { "Horse", new List<int> { 1, 25 } },
            { "Turtle", new List<int> {1, 150} }
        };

        private readonly List<string> owners = new List<string> { "Alice", "Bob", "Charlie", "Dave", "Eva", "Jhonny", "Peter", "Evelyn", "Steve", "Charles", "Victoria" };
        private readonly List<string> genders = new List<string> { "Male", "Female" };

        private readonly Random random = new Random();

        public Pet GetRandomPet(Dictionary<string, List<string>> availableImages, out string animalType)
        {
            animalType = animalTypes[random.Next(animalTypes.Count)];
            return GenerateSpecificPet(animalType, availableImages);
        }

        private Pet GenerateSpecificPet(string animalType, Dictionary<string, List<string>> availableImages)
        {
            var name = petNames[animalType][random.Next(petNames[animalType].Count)];

            var imageList = availableImages[animalType];
            if (imageList.Count == 0)
            {
                throw new InvalidOperationException($"No more images available for {animalType}");
            }

            var imageIndex = random.Next(imageList.Count);
            var imageUrl = imageList[imageIndex];
            imageList.RemoveAt(imageIndex);

            var ageRange = petAgeRanges[animalType];
            var age = random.Next(ageRange[0], ageRange[1] + 1);

            return new Pet
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                ImageUrl = imageUrl,
                Age = age,
                Gender = genders[random.Next(genders.Count)],
                Owner = owners[random.Next(owners.Count)],
                AnimalType = animalType 
            };
        }

        public List<Pet> GenerateRandomPets(int number, out Dictionary<string, int> animalTypeCounts)
        {
            var pets = new List<Pet>();
            animalTypeCounts = new Dictionary<string, int>();

            var availableImages = new Dictionary<string, List<string>>();
            foreach (var animalType in petImages.Keys)
            {
                availableImages[animalType] = new List<string>(petImages[animalType]);
            }

            for (int i = 0; i < number; i++)
            {
                try
                {
                    var pet = GetRandomPet(availableImages, out string animalType);

                    if (!animalTypeCounts.ContainsKey(animalType))
                    {
                        animalTypeCounts[animalType] = 0;
                    }

                    animalTypeCounts[animalType]++;
                    pets.Add(pet);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("No more available images found for an animal type.");
                }
            }

            return pets;
        }
    }
}
