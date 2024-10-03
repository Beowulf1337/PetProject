using PetApiProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetApiProgram.Services
{
    public class PetService
    {
        // list with the different type off animals that is included in the program at the moment
        private readonly List<string> animalTypes = new List<string> { "Cat", "Dog", "Bird", "Horse", "Turtle" };

        // dictionary which contains the names that the randomly created animals can choose from depending on their type and gender
        private readonly Dictionary<string, Dictionary<string, List<string>>> petNames = new Dictionary<string, Dictionary<string, List<string>>>
        {

            // the list dictonary containing the names availible for male and female cats
            { "Cat", new Dictionary<string, List<string>> {

                // list off male cat names
                { "Male", new List<string> { "Charlie", "Felix", "Finley", "Buddy", "Ralph", "Oscar", "Milo", "George",
                                             "Tigger", "Alfie", "Jasper", "Max", "Tiger", "Simba", "Bob", "Casper", "Fred",
                                             "Freddie", "Tommy", "Gizmo", "Harry", "Oliver", "Joey", "Drake", "Bello" } },

                // list off male cat names
                { "Female", new List<string> {"Poppy", "Bella", "Misty", "Molly", "Daisy", "Tilly", "Luna", "Lily", "Lilly",
                                              "Willow", "Coco", "Betty", "Missy", "Sophie", "Belle", "Cleo", "Izzy", "Hana", "Mika" } }
            }},

            // the list dictonary containing the names availible for male and female dogs
            { "Dog", new Dictionary<string, List<string>> {

                // list off male dog names
                { "Male", new List<string> { "Charlie", "Max", "Milo", "Cooper", "Rocky", "Buddy", "Bear", "Teddy", "Harley", "Duke",
                                             "Zeus", "Blue", "Jack", "Loki", "Leo", "Oliver", "Tucker", "Koda", "Toby", "Bentley",
                                             "Jax", "Kobe", "Piper", "Ace", "Finn", "Ollie", "Louie", "Scout", "Apollo", "Winston"} },

                // list off female dog names
                { "Female", new List<string> {"Luna", "Bella", "Daisy", "Lucy", "Bailey", "Coco", "Lola", "Nala", "Sadie", "Stella",
                                              "Penny", "Molly", "Maggie", "Rosie", "Zoey", "Ruby", "Lily", "Nova", "Ellie", "Chloe",
                                              "Pepper", "Mia", "Riley", "Roxy", "Willow", "Millie", "Sophie", "Oreo", "Gracie", "Hazel"} }
            }},

            // the list dictonary containing the names availible for male and female birds
            { "Bird", new Dictionary<string, List<string>> {

                // list off male bird names
                { "Male", new List<string> { "Barry", "Benny", "Bertram", "Clive", "Clyde", "Duke", "Dusty", "Floyd", "Fred", "Freddy",
                                             "Harley", "Hawk", "Jasper", "Jay", "Jay Bird", "Jeffrey", "Jerry", "Joey", "Jonah", "Judah",
                                             "Kevin", "Kody", "Lark", "Larry", "Lewis", "Lorenzo", "Louie", "Maynard", "Mister Misty",
                                             "Mr. Nat", "Neil", "Noah", "Norman", "Oliver", "Oscar", "Ozzy", "Pauley"} },

                // list off female bird names
                { "Female", new List<string> { "Aja", "Ala", "Angelica", "Aubrey", "Ava", "Bella", "Birdie", "Bonnie", "Brittany", "Cher",
                                               "Chloe", "Connie", "Cynthia", "Gabby", "Greta", "Holly", "Indira", "Isabella", "Jenny",
                                               "Kira", "Laila", "Lexey", "Mama", "Mia", "Miss Pretty", "Nancy", "Nicky", "Opal", "Paloma",
                                               "Penny", "Sherry", "Simone", "Susan", "Suzie", "Teal", "Tori", "Valentina", "Yara"} }
            }},

            // the list dictonary containing the names availible for male and female horses
            { "Horse", new Dictionary<string, List<string>> {

                // list off male horse names
                { "Male", new List<string> { "Al", "Albert", "Angus", "Barbaro", "Bart", "Bert", "Benjamin", "Benny", "Blaze", "Bucephalus",
                                             "Buddy", "Carl", "Cash", "Chuck", "Chucky", "Dart", "Dennis", "Denny", "Doggy", "Donnie", "Ed",
                                             "Edison", "Edward", "Elmer", "Frankel", "Freckles", "Godolphin", "Jameson", "Jim", "Joe",
                                             "Manny", "Marengo", "Marvin", "Max", "Ned", "Ollie", "Opus", "Pal", "Percy", "President",
                                             "Sergeant Reckless", "Sheldon", "Sheriff", "Stewart", "Stewie", "Tank", "Ted", "Timmy",
                                             "Traveller", "Trigger"} },

                // list off female horse names
                { "Female", new List<string> { "Abby", "Annabelle", "Annie", "Autumn", "Bella", "Berta", "Betsy", "Bossy", "Carly", "Caroline",
                                               "Chloe", "Cookie", "Daisy", "Dolly", "Eleanor", "Ellie", "Fancy", "Flo", "Ginny", "Hailey",
                                               "Holly", "Jade", "Jasmine", "Jenny", "Juliet", "Lady", "Ladybird", "Luna", "Marigold", "Martha",
                                               "Mary", "Meadow", "Nancy", "Nel", "Nelly", "Pearl", "Penny", "Piper", "Princess", "Queen", "Queenie",
                                               "Roseanne", "Rosebud", "Rosie", "Sadie", "Sally", "Sassy", "Shania", "Shelby", "Shirley", "Valerie",
                                               "Venus", "Wanda", "Wendy", "Willow"} }
            }},

            // the list dictonary containing the names availible for male and female turtles
            { "Turtle", new Dictionary<string, List<string>> {

                // list off male turtle names
                { "Male", new List<string> { "Achilles", "Apollo", "Atlas", "Balboa", "Baldwin", "Bowser", "Bruno", "Bubbles", "Charles", "Duke", "Emmet",
                                             "Frank", "Fergus", "Harley", "Hercules", "Hermes", "Hunter", "Kai", "Lemmy", "Leo", "Malcolm", "Melvin",
                                             "Mikey", "Mustafa", "Oogway", "Oscar", "Ozzy", "Popeye", "Paulie", "Pickle", "Poke", "Popeye", "Ramone",
                                             "Romeo", "Rufus", "Taco", "Waddles", "Donatello", "Leonardo", "Michelangelo", "Raphael"} }, 

                // list off male turtle names
                { "Female", new List<string> { "Shelly", "Tina", "Tilly", "April", "Arcadia", "Ariel", "Aspen", "August", "Bertie", "Beryl", "Chartreuse",
                                               "Cherry", "Dolores", "Donna", "Elphaba", "Emma", "Fran", "Francesca", "Francine", "Giada", "Ginger",
                                               "Goldie", "Holly", "Ivy", "Jade", "Kelly", "Kenya", "Kiwi", "Lady Boxworthy", "Lana", "Lily", "Michelle",
                                               "Myrtle", "Molasses", "Olive", "Opal", "Penny", "Raffaella", "Ramona", "Ruby", "Sabrina", "Sienna", "Tammy"} }
            }}
        };

        //  dictionary containing lists off images for each animal type to pick from to use
        private readonly Dictionary<string, List<string>> petImages = new Dictionary<string, List<string>>
        {

            // list off cat images
            { "Cat", new List<string> { "https://localhost:7172/Images/CatImages/orangeCat1.jpg", "https://localhost:7172/Images/CatImages/orangeCat3.jpg",
                                        "https://localhost:7172/Images/CatImages/beigeCat1.jpg", "https://localhost:7172/Images/CatImages/beigeCat1.jpg",
                                        "https://localhost:7172/Images/CatImages/grayCat1.jpg", "https://localhost:7172/Images/CatImages/orangeCat4.jpg",
                                        "https://localhost:7172/Images/CatImages/whiteAndBlackCat1.jpg", "https://localhost:7172/Images/CatImages/whiteCat1.jpg",
                                        "https://localhost:7172/Images/CatImages/orangeCat5.jpg", "https://localhost:7172/Images/CatImages/whiteAndGrayCat1.jpg",
                                        "https://localhost:7172/Images/CatImages/bengalCat1.jpg"} },

            // list off dog images
            { "Dog", new List<string> { "https://localhost:7172/Images/DogImages/smallDog2.jpg", "https://localhost:7172/Images/DogImages/mediumDog1.jpg",
                                        "https://localhost:7172/Images/DogImages/mediumDog2.jpg", "https://localhost:7172/Images/DogImages/mediumDog3.jpg",
                                        "https://localhost:7172/Images/DogImages/mediumDog4.jpg", "https://localhost:7172/Images/DogImages/smallDog3.jpg",
                                        "https://localhost:7172/Images/DogImages/smallDog4.jpg", "https://localhost:7172/Images/DogImages/smallDog5.jpg",
                                        "https://localhost:7172/Images/DogImages/smallDog6.jpg", "https://localhost:7172/Images/DogImages/largeDog1.jpg",
                                        "https://localhost:7172/Images/DogImages/largeDog2.jpg", "https://localhost:7172/Images/DogImages/largeDog3.jpg"} },

            // list off bird images
            { "Bird", new List<string> { "https://localhost:7172/Images/BirdImages/birdParrot1.jpg", "https://localhost:7172/Images/BirdImages/birdParrot2.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdParrot3.jpg", "https://localhost:7172/Images/BirdImages/birdParrot4.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdParrot5.jpg", "https://localhost:7172/Images/BirdImages/birdWild1.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdWild2.jpg", "https://localhost:7172/Images/BirdImages/birdWild3.jpg",
                                         "https://localhost:7172/Images/BirdImages/birdCorvid1.jpg", "https://localhost:7172/Images/BirdImages/birdCorvid2.jpg"} },

            // list off horse images
            { "Horse", new List<string> { "https://localhost:7172/Images/HorseImages/whiteHorse1.jpg", "https://localhost:7172/Images/HorseImages/brownHorse1.jpg",
                                          "https://localhost:7172/Images/HorseImages/brownHorse2.jpg", "https://localhost:7172/Images/HorseImages/whiteHorse2.jpg",
                                          "https://localhost:7172/Images/HorseImages/whiteHorse3.jpg", "https://localhost:7172/Images/HorseImages/blackHorse1.jpg",
                                          "https://localhost:7172/Images/HorseImages/blackWorkHorse1.jpg", "https://localhost:7172/Images/HorseImages/blondeHorse1.jpg",
                                          "https://localhost:7172/Images/HorseImages/blondeHorse1.jpg"} },

            // list off turtle images
            { "Turtle", new List<string>{ "https://localhost:7172/Images/TurtleImages/smallTurtle1.jpg", "https://localhost:7172/Images/TurtleImages/seaTurtle1.jpg",
                                          "https://localhost:7172/Images/TurtleImages/mediumTurtle1.jpg", "https://localhost:7172/Images/TurtleImages/snappingTurtle1.jpg",
                                          "https://localhost:7172/Images/TurtleImages/smallTurtle2.jpg", "https://localhost:7172/Images/TurtleImages/smallTurtle3.jpg",
                                          "https://localhost:7172/Images/TurtleImages/smallTurtle4.jpg" } }
        };

        // dictionary containing lists off the different animal types age ranges for them to use to pick an age from
        private readonly Dictionary<string, List<int>> petAgeRanges = new Dictionary<string, List<int>>
        {
            // list off cat ages to chose from between the age of 1 to 20
            { "Cat", new List<int> { 1, 20 } },

             // list off dog ages to chose from between the age of 1 to 20
            { "Dog", new List<int> { 1, 15 } },

             // list off bird ages to chose from between the age of 1 to 20
            { "Bird", new List<int> { 1, 10 } },

             // list off horse ages to chose from between the age of 1 to 20
            { "Horse", new List<int> { 1, 25 } },

             // list off turtle ages to chose from between the age of 1 to 20
            { "Turtle", new List<int> {1, 150} }
        };

        // a long list containing alot off names that can be chosen as the owner off the generated pets
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

        // a short list containing the two genders that the generated animal can pick from
        private readonly List<string> genders = new List<string> { "Male", "Female" };

        // initlization off a read only class used to randomly generate numbers
        private readonly Random random = new Random();

        // a method used to get a random pet from the availible options
        public Pet GetRandomPet(Dictionary<string, List<string>> availableImages, out string animalType)
        {

            // select a random animal type from the ones availible
            animalType = animalTypes[random.Next(animalTypes.Count)];

            // randomly chose then gender off the pet between male and female 
            string gender = random.Next(2) == 0 ? "Male" : "Female";

            // generate a specifikc pet based on the selected animal type and gender
            return GenerateSpecificPet(animalType, gender, availableImages);
        }

        // a method used to generate a specific pet based on the previously chosen animal type and gender from GetRandomPet
        private Pet GenerateSpecificPet(string animalType, string gender, Dictionary<string, List<string>> availableImages)
        {

            // get the list off names depending on the previously chosen animal type and gender
            var nameList = petNames[animalType][gender];

            // randomly select one off the names from the respective name list to use
            var name = nameList[random.Next(nameList.Count)];

            // get the list off images for the chosen animal type
            var imageList = availableImages[animalType];

            // make sure there are images left for that animal that havent been used yet and if not send a warning
            if (imageList.Count == 0)
            {
                throw new InvalidOperationException($"No more images available for {animalType}");
            }

            // randomly pick one off the images and then retrieve the url for that chosen image
            var imageIndex = random.Next(imageList.Count);
            var imageUrl = imageList[imageIndex];

            // remove the chosen image from the used image list to avoid duplicate images being used
            imageList.RemoveAt(imageIndex);

            // get the age range for the chosen animal type
            var ageRange = petAgeRanges[animalType];

            // randomly chose an age within the animal types specific age range
            var age = random.Next(ageRange[0], ageRange[1] + 1);

            // create a new pet with all the randomly assigned values
            return new Pet
            {

                // give the new pet a unique id number
                Id = Guid.NewGuid().ToString(),

                // set the pets name
                Name = name,

                // set the pets image url 
                ImageUrl = imageUrl,

                // set the pets age
                Age = age,

                // set the pets gender
                Gender = gender,

                // set the type of pet
                AnimalType = animalType,

                // set the owner of the pet
                Owner = owners[random.Next(owners.Count)]
            };
        }

        // a method used to generate a specific amount of pets
        public List<Pet> GenerateRandomPets(int number, out Dictionary<string, int> animalTypeCounts)
        {

            // create a list to hold all the pets
            var pets = new List<Pet>();

            // create a dictionary which counts how many pets off each animal type it created
            animalTypeCounts = new Dictionary<string, int>();

            // create a coupe off the images that are availible for generating a pet
            var availableImages = new Dictionary<string, List<string>>();
            foreach (var animalType in petImages.Keys)
            {
                availableImages[animalType] = new List<string>(petImages[animalType]);
            }

            // generate the specific number of pets
            for (int i = 0; i < number; i++)
            {
                try
                {
                    // get a random pet and their corresponding animal type
                    var pet = GetRandomPet(availableImages, out string animalType);

                    // if this type off animal hasnt been counted yet then initilize its count as zero
                    if (!animalTypeCounts.ContainsKey(animalType))
                    {
                        animalTypeCounts[animalType] = 0;
                    }
                    // increment the count for the animal type 
                    animalTypeCounts[animalType]++;

                    // add the generated pet to the pets list
                    pets.Add(pet);
                }
                catch (InvalidOperationException)
                {

                    // handle the case where there are no more availible images for the chosen animal type
                    Console.WriteLine("No more unique available images found for an animal type.");
                }
            }

            // return the list of the generate pets
            return pets;
        }

        // method to add a pet to the internal list
        private readonly List<Pet> _pets = new List<Pet>();

        // method to add a new pet to the pet list
        public Pet AddPet(Pet newPet)
        {

            // create a unique id for the pet
            newPet.Id = Guid.NewGuid().ToString();

            // add the new pet to the list off pets
            _pets.Add(newPet);

            // return the newly added pet
            return newPet;
        }

        // method to get a pet from its unique id 
        public Pet? GetPetById(string id)
        {

            // search for a pet with the matching id and return it, if a pet with the id is not found return null
            return _pets.FirstOrDefault(p => p.Id == id);
        }
    }
}