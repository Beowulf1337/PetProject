using Microsoft.AspNetCore.Mvc;
using PetApiProgram.Models;
using PetApiProgram.Services;
using System.Collections.Generic;

namespace PetApiProgram.Controllers
{

    // attribute to set the base route for the controller, controller will be replaced by the name off controller
    [Route("api/[controller]")]

    // indicates that this class is an api controller
    [ApiController]

    // defining the PetsController class and that it is inheriting from ControllerBase
    public class PetsController : ControllerBase
    {

        // declares a private read only instance of PetService
        private readonly PetService _petService;

        // constructor for PetsController
        public PetsController()
        {

            // initilizing the PetService instance
            _petService = new PetService();
        }

        // endpoint which is used to generate a specific number of random pets
        [HttpGet("generate/{number}")]
        public IActionResult GeneratePets(int number)
        {
            // Generate random pets and ignore the animal type counts
            var pets = _petService.GenerateRandomPets(number, out _); 

            // Return the generated pets
            return Ok(pets);
        }

        // endpoint to add a new pet

        // route for this actions method which specifies it handles post requests
        [HttpPost]

        // method for adding a new pet accepting the pet object as a parameter
        public Pet AddPet(Pet newPet)
        {

            // return the newly added pet
                return newPet;
        }
    }
}
