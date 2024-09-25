using Microsoft.AspNetCore.Mvc;
using PetApiProgram.Models;
using PetApiProgram.Services;
using System.Collections.Generic;

namespace PetApiProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly PetService _petService;

        public PetsController()
        {
            _petService = new PetService();
        }

        [HttpGet("generate/{number}")]
        public IActionResult GeneratePets(int number)
        {
            var pets = _petService.GenerateRandomPets(number);
            var maleCount = pets.Count(pet => pet.Gender == "Male");
            var femaleCount = pets.Count(pet => pet.Gender == "Female");

            var stats = new
            {
                Total = pets.Count,
                Male = maleCount,
                Female = femaleCount
            };

            return Ok(new { Pets = pets, Stats = stats });
        }
    }
}
