namespace PetApiProgram.Models
{

    // represents the pet entity in the pet api
    public class Pet
    {

        // unique identifier for the pet
        public string Id { get; set; } = string.Empty;

        // the name of the pet
        public string Name { get; set; } = string.Empty;

        // url of the pets image
        public string ImageUrl { get; set; } = string.Empty;

        // the pets age
        public int Age { get; set; }

        // the pets gender
        public string Gender { get; set; } = string.Empty;

        // the pets owner
        public string Owner { get; set; } = string.Empty;

        // the type of pet
        public string AnimalType { get; set; } = string.Empty;
    }
}
