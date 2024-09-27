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
            { "Cat", new List<string> { "Whiskers", "Fluffy", "Bella", "Luna", "Findus", "Poppy", "Bella", "Misty", "Charlie", 
                                        "Molly", "Smudge", "Daisy", "Oscar", "Tilly", "Milo", "Tigger", "George", 
                                        "Alfie", "Felix", "Lily", "Rosie", "Lilly", "Millie", "Tiger", "Willow", 
                                        "Coco", "Gizmo", "Betty", "Jasper", "Max", "Simba", "Smokey", "Sox", "Fluffy", 
                                        "Missy", "Oreo", "Sophie", "Belle", "Cookie", "Cleo", "Lucy", "Pebbles", "Pepper", 
                                        "Harry", "Lola", "Mia", "Patch", "Ruby", "Sooty", "Bob", "Casper", "Jess", "Ziggy", "Angel", 
                                        "Bailey", "Fred", "Holly", "Maisie", "Billy", "Bonnie", "Freddie", "Princess", "Tabitha", "Tinkerbell", 
                                        "Tommy", "Bobby", "Fifi", "Fudge", "Milly", "Oliver", "Snowy", "Tia", "Tom", "Annie", "Bertie", "Brian", "Flo", 
                                        "Jerry", "Kitty", "Maisy", "Meg", "Nala", "Phoebe", "Shadow", "Teddy", "Evie", "Florence", "Minnie", "OLLIE", "Polly", 
                                        "Pumpkin", "Toby", "Barney", "Boo", "Bubbles", "Chloe", "Garfield", "Ginger", "Ginny", "Henry", "Izzy", "Joey", "Nemo", "Rio" } },
            { "Dog", new List<string> { "Buddy", "Max", "Charlie", "Milo", "Max", "Charlie", "Bella", "Poppy", "Daisy", "Buster", "Alfie", "Millie",
                                        "Molly", "Rosie", "Buddy", "Barney", "Lola", "Roxy", "Ruby", "Tilly",
                                        "Bailey", "Marley", "Tia", "Bonnie", "Toby", "Milo", "Archie", "Holly",
                                        "Lucy", "Lexi", "Bruno", "Rocky", "Sasha", "Billy", "Gerbil", "Bear",
                                        "Oscar", "Jack", "Lady", "Willow", "Tyson", "Benji", "Jake",
                                        "Jess", "Teddy", "Coco", "Murphy", "Sky", "Honey", "Lilly", "Lily",
                                        "Monty", "Patch", "Rolo", "Harry", "Maisy", "Pippa", "Trixie", "Bruce",
                                        "Dexter", "Freddie", "Jasper", "Shadow", "Milly", "Missy", "Pepper",
                                        "Rex", "Sally", "Zeus", "Bobby", "Harvey", "Lucky", "Ollie", "Pip",
                                        "Sam", "Storm", "Amber", "Belle", "Cooper", "Fudge", "Meg", "Minnie",
                                        "Ozzy", "Ralph", "Tess", "Dave", "Diesel", "George", "Jessie", "Leo",
                                        "Lottie", "Louie", "Prince", "Reggie", "Simba", "Skye", "Basil",
                                        "Betsy", "Chase", "Dolly", "Frankie", "Lulu", "Maggie"} },
            { "Bird", new List<string> { "Tweety", "Sky", "Sunny", "Rio", "Barry", "Benny", "Bertram", "Clive", "Clyde", "Duke", 
                                         "Dusty", "Floyd", "Fred", "Freddy", "Harley", "Hawk", "Jasper", "Jay", 
                                        "Jay Bird", "Jeffrey", "Jerry", "Joey", "Jonah", "Judah", "Kevin", "Kody", 
                                        "Lark", "Larry", "Lewis", "Lorenzo", "Louie", "Maynard", "Mister Misty", 
                                        "Mr. Nat", "Neil", "Noah", "Norman", "Oliver", "Oscar", "Ozzy", "Pauley", 
                                        "Pax", "Perry", "Petey", "Phoenix", "Ralph", "Ricky", "Snowy", "Sonny", 
                                        "Sunny", "Tanner", "Ted", "Theodore", "TJ", "Tucker", "Wyatt", "Aja", 
                                        "Ala", "Angelica", "Aubrey", "Ava", "Bella", "Birdie", "Bonnie", "Brittany", 
                                        "Cher", "Chloe", "Connie", "Cynthia", "Gabby", "Greta", "Holly", "Indira", 
                                        "Isabella", "Jenny", "Kira", "Laila", "Lexey", "Mama", "Mia", "Miss Pretty", 
                                        "Nancy", "Nicky", "Opal", "Paloma", "Penny", "Sherry", "Simone", "Susan", 
                                        "Suzie", "Teal", "Tori", "Valentina", "Yara", "Angel", "April", "Baby", 
                                        "Baby Boy", "Bangles", "Bee Bop", "Belle Star", "Boardwalk", "Bobbit", 
                                        "Butterbean", "Cackle", "Cassie", "Chickie", "Dotty", "Hootie", "Itsy", 
                                        "Kiki", "Lucky", "Pepper", "Perky", "Pretty", "Pretzel", "Quigley", "Sam", 
                                        "Sammy", "Sherbert", "Skittles", "Sweetie", "Tango" } },
            { "Horse", new List<string> {"Pegasus", "Bucephalus", "Seabiscuit", "Comanche", "Al", "Albert", "Angus", "Barbaro", "Bart", 
                                        "Bert", "Benjamin", "Benny", "Blaze", "Buddy", "Carl", "Cash", "Chuck", 
                                        "Chucky", "Dart", "Dennis", "Denny", "Doggy", "Donnie", "Ed", "Edison", 
                                        "Edward", "Elmer", "Frankel", "Freckles", "Godolphin", "Jameson", "Jim", 
                                        "Joe", "Manny", "Marengo", "Marvin", "Max", "Ned", "Ollie", "Opus", "Pal", 
                                        "Percy", "President", "Sergeant Reckless", "Sheldon", "Sheriff", "Stewart", 
                                        "Stewie", "Tank", "Ted", "Timmy", "Traveller", "Trigger", "Abby", "Annabelle", 
                                        "Annie", "Autumn", "Bella", "Berta", "Betsy", "Bossy", "Carly", "Caroline", 
                                        "Chloe", "Cookie", "Daisy", "Dolly", "Eleanor", "Ellie", "Fancy", "Flo", 
                                        "Ginny", "Hailey", "Holly", "Jade", "Jasmine", "Jenny", "Juliet", "Lady", 
                                        "Ladybird", "Luna", "Marigold", "Martha", "Mary", "Meadow", "Nancy", "Nel", 
                                        "Nelly", "Pearl", "Penny", "Piper", "Princess", "Queen", "Queenie", "Roseanne", 
                                        "Rosebud", "Rosie", "Sadie", "Sally", "Sassy", "Shania", "Shelby", "Shirley", 
                                        "Valerie", "Venus", "Wanda", "Wendy", "Willow" } },
            { "Turtle", new List<string> { "Leonardo", "Donatello", "Michelangelo", "Raphael", "April", "Arcadia", "Ariel", "Aspen", "August", 
                                        "Bertie", "Beryl", "Chartreuse", "Cherry", "Dolores", "Donna", "Elphaba", 
                                        "Emma", "Fran", "Francesca", "Francine", "Giada", "Ginger", "Goldie", 
                                        "Holly", "Ivy", "Jade", "Kelly", "Kenya", "Kiwi", "Lady Boxworthy", 
                                        "Lana", "Lily", "Michelle", "Myrtle", "Molasses", "Olive", "Opal", 
                                        "Penny", "Raffaella", "Ramona", "Ruby", "Sabrina", "Sienna", "Tammy", 
                                        "Achilles", "Apollo", "Atlas", "Balboa", "Baldwin", "Bowser", "Bruno", 
                                        "Bubbles", "Charles", "Duke", "Emmet", "Frank", "Fergus", "Harley", 
                                        "Hercules", "Hermes", "Hunter", "Kai", "Lemmy", "Leo", "Malcolm", "Melvin", 
                                        "Mikey", "Mustafa", "Oogway", "Oscar", "Ozzy", "Popeye", "Paulie", "Pickle", 
                                        "Poke", "Popeye", "Ramone", "Romeo", "Rufus", "Taco", "Waddles", "Amarilla", 
                                        "Amarillo", "Bulldozer", "Celadon", "Erin", "Flippy", "Jaune", "Gialla",
                                        "Giallo", "Hard Top", "Harlequin", "Kombu", "Laurel", "Lenta", "Lento", 
                                        "Malachite", "Pokey", "Red", "Reseda", "Rosy", "Scooter", "Shell-Shocker", 
                                        "Shelly", "Shyman", "Slider", "Slow Poke", "Snapper", "Snappy", "Stretch", 
                                        "Stumpy", "Swimmer", "Tank", "Tonka", "Tucker", "Umi", "Verde", "Verte" } }
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
