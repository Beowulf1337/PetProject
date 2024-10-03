namespace PetApiProgram.Models
{

    // represents the pet entity in the pet api
    public class Pet
    {

        // unique identifier for the pet
        public string Id { get; set; }

        // the name of the pet
        public string Name { get; set; }

        // url of the pets image
        public string ImageUrl { get; set; }

        // the pets age
        public int Age { get; set; }

        // the pets gender
        public string Gender { get; set; }

        // the pets owner
        public string Owner { get; set; }

        // the type of pet
        public string AnimalType { get; set; }
    }
}
