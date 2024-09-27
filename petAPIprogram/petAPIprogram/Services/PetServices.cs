using PetApiProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetApiProgram.Services
{
    public class PetService
    {
        private readonly List<string> animalTypes = new List<string> { "Cat", "Dog", "Bird", "Horse", "Turtle" };

        private readonly Dictionary<string, Dictionary<string, List<string>>> petNames = new Dictionary<string, Dictionary<string, List<string>>>
        {
            { "Cat", new Dictionary<string, List<string>> {
                { "Male", new List<string> { "Whiskers", "Fluffy", "Oliver", "Simba" } },
                { "Female", new List<string> { "Bella", "Luna", "Sophie", "Molly" } }
            }},
            { "Dog", new Dictionary<string, List<string>> {
                { "Male", new List<string> { "Buddy", "Max", "Charlie", "Rocky" } },
                { "Female", new List<string> { "Daisy", "Lucy", "Lola", "Sadie" } }
            }},
            { "Bird", new Dictionary<string, List<string>> {
                { "Male", new List<string> { "Tweety", "Sky", "Rio", "Jack" } },
                { "Female", new List<string> { "Sunny", "Mimi", "Chirpy", "Kiwi" } }
            }},
            { "Horse", new Dictionary<string, List<string>> {
                { "Male", new List<string> { "Spirit", "Shadow", "Thunder", "Blaze" } },
                { "Female", new List<string> { "Bella", "Luna", "Daisy", "Sophie" } } 
            }},
            { "Turtle", new Dictionary<string, List<string>> {
                { "Male", new List<string> { "Shelly", "Speedy", "Franklin", "Turtly" } }, 
                { "Female", new List<string> { "Shelly", "Tina", "Tilly", "Luna" } } 
            }}
        };

        private readonly Dictionary<string, List<string>> petImages = new Dictionary<string, List<string>>
        {
            { "Cat", new List<string> { "https://localhost:7172/Images/CatImages/orangeCat1.jpg", "https://localhost:7172/Images/CatImages/orangeCat3.jpg",
                                        "https://localhost:7172/Images/CatImages/beigeCat1.jpg", "https://localhost:7172/Images/CatImages/beigeCat1.jpg",
                                        "https://localhost:7172/Images/CatImages/grayCat1.jpg", "https://localhost:7172/Images/CatImages/orangeCat4.jpg",
                                        "https://localhost:7172/Images/CatImages/whiteAndBlackCat1.jpg", "https://localhost:7172/Images/CatImages/whiteCat1.jpg",
                                        "https://localhost:7172/Images/CatImages/orangeCat5.jpg", "https://localhost:7172/Images/CatImages/whiteAndGrayCat1.jpg",
                                        "https://localhost:7172/Images/CatImages/bengalCat1.jpg"} },
            { "Dog", new List<string> { "https://localhost:7172/Images/DogImages/smallDog2.jpg", "https://localhost:7172/Images/DogImages/mediumDog1.jpg",
                                        "https://localhost:7172/Images/DogImages/mediumDog2.jpg", "https://localhost:7172/Images/DogImages/mediumDog3.jpg",
                                        "https://localhost:7172/Images/DogImages/mediumDog4.jpg", "https://localhost:7172/Images/DogImages/smallDog3.jpg",
                                        "https://localhost:7172/Images/DogImages/smallDog4.jpg", "https://localhost:7172/Images/DogImages/smallDog5.jpg",
                                        "https://localhost:7172/Images/DogImages/smallDog6.jpg", "https://localhost:7172/Images/DogImages/largeDog1.jpg",
                                        "https://localhost:7172/Images/DogImages/largeDog2.jpg", "https://localhost:7172/Images/DogImages/largeDog3.jpg"} },
            { "Bird", new List<string> { "https://localhost:7172/Images/BirdImages/birdParrot1.jpg", "https://localhost:7172/Images/BirdImages/birdParrot2.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdParrot3.jpg", "https://localhost:7172/Images/BirdImages/birdParrot4.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdParrot5.jpg", "https://localhost:7172/Images/BirdImages/birdWild1.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdWild2.jpg", "https://localhost:7172/Images/BirdImages/birdWild3.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdCorvid1.jpg", "https://localhost:7172/Images/BirdImages/birdCorvid2.jpg"} },
            { "Horse", new List<string> { "https://localhost:7172/Images/HorseImages/whiteHorse1.jpg", "https://localhost:7172/Images/HorseImages/brownHorse1.jpg",
                                          "https://localhost:7172/Images/HorseImages/brownHorse2.jpg", "https://localhost:7172/Images/HorseImages/whiteHorse2.jpg",
                                          "https://localhost:7172/Images/HorseImages/whiteHorse3.jpg", "https://localhost:7172/Images/HorseImages/blackHorse1.jpg",
                                          "https://localhost:7172/Images/HorseImages/blackWorkHorse1.jpg", "https://localhost:7172/Images/HorseImages/blondeHorse1.jpg",
                                          "https://localhost:7172/Images/HorseImages/blondeHorse1.jpg"} },
            { "Turtle", new List<string>{ "https://localhost:7172/Images/TurtleImages/smallTurtle1.jpg", "https://localhost:7172/Images/TurtleImages/seaTurtle1.jpg",
                                          "https://localhost:7172/Images/TurtleImages/mediumTurtle1.jpg", "https://localhost:7172/Images/TurtleImages/snappingTurtle1.jpg",
                                          "https://localhost:7172/Images/TurtleImages/smallTurtle2.jpg", "https://localhost:7172/Images/TurtleImages/smallTurtle3.jpg",
                                          "https://localhost:7172/Images/TurtleImages/smallTurtle4.jpg" } } 
        };

        private readonly Dictionary<string, List<int>> petAgeRanges = new Dictionary<string, List<int>>
        {
            { "Cat", new List<int> { 1, 20 } },
            { "Dog", new List<int> { 1, 15 } },
            { "Bird", new List<int> { 1, 10 } },
            { "Horse", new List<int> { 1, 25 } },
            { "Turtle", new List<int> {1, 150} }
        };

        private readonly List<string> owners = new List<string> { "Alice", "Bob", "Charlie", "Dave", "Eva", "Jhonny", "Peter", "Evelyn", "Steve", 
                                                                  "Charles", "Victoria", "Pettson", "James", "Mary", "Michael", 
                                                                  "Patricia", "Robert", "Jennifer", "John", "Linda", "David", 
                                                                  "Elizabeth", "William", "Barbara", "Richard", "Susan", "Joseph", 
                                                                  "Jessica", "Thomas", "Karen", "Christopher", "Sarah", "Charles", 
                                                                  "Lisa", "Daniel", "Nancy", "Matthew", "Sandra", "Anthony", "Betty", 
                                                                  "Mark", "Ashley", "Donald", "Emily", "Steven", "Kimberly", "Andrew", 
                                                                  "Margaret", "Paul", "Donna", "Joshua", "Michelle", "Kenneth", "Carol", 
                                                                  "Kevin", "Amanda", "Brian", "Melissa", "Timothy", "Deborah", "Ronald", 
                                                                  "Stephanie", "George", "Rebecca", "Jason", "Sharon", "Edward", "Laura", 
                                                                  "Jeffrey", "Cynthia", "Ryan", "Dorothy", "Jacob", "Amy", "Nicholas", 
                                                                  "Kathleen", "Gary", "Angela", "Eric", "Shirley", "Jonathan", "Emma", 
                                                                  "Stephen", "Brenda", "Larry", "Pamela", "Justin", "Nicole", "Scott", 
                                                                  "Anna", "Brandon", "Samantha", "Benjamin", "Katherine", "Samuel", 
                                                                  "Christine", "Gregory", "Debra", "Alexander", "Rachel", "Patrick", 
                                                                  "Carolyn", "Frank", "Janet", "Raymond", "Maria", "Jack", "Olivia", 
                                                                  "Dennis", "Heather", "Jerry", "Helen"};
        private readonly List<string> genders = new List<string> { "Male", "Female" };

        private readonly Random random = new Random();

        public Pet GetRandomPet(Dictionary<string, List<string>> availableImages, out string animalType)
        {
            animalType = animalTypes[random.Next(animalTypes.Count)];
            string gender = random.Next(2) == 0 ? "Male" : "Female";
            return GenerateSpecificPet(animalType, gender, availableImages);
        }
        private Pet GenerateSpecificPet(string animalType, string gender, Dictionary<string, List<string>> availableImages)
        {
            var nameList = petNames[animalType][gender];
            var name = nameList[random.Next(nameList.Count)];

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
                Gender = gender,
                Owner = owners[random.Next(owners.Count)]
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