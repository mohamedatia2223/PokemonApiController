using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;
using PokemonReviewApp.InterFace.Repo;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepo _repo;

        public OwnerController(IOwnerRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwner()
        {
            var pokemons = await _repo.GetAllOwners();
            return Ok(pokemons);
        }

        [HttpGet("getOwnerByName/{OwnerName}")]
        public async Task<IActionResult> GetPokemonByName(string OwnerName)
        {
            if (!await _repo.OnwerExist(OwnerName))
                return NotFound($"No Pokémon named '{OwnerName}' found.");

            var pokeDto = await _repo.GetOwnerByName(OwnerName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokeDto);
        }
        [HttpGet("GetOwnerByPokemon")]
        public async Task<IActionResult> GetOwnerByPokemon(string pokemonName)
        {
            var c = await _repo.GetOwnerByPokemon(pokemonName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(c);
        }

        [HttpPost("AddOwner")]
        public async Task<IActionResult> AddOwner([FromForm] OwnerDTO owner)
        {
            await _repo.AddOwner(owner);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
        [HttpPut("UpdateOwnerAndAssignPokemon")]
        public async Task<IActionResult> UpdateOwnerAndAssignPok(string ownerName, [FromForm] OwnerDTO owner,string pokemonName)
        {
            await _repo.UpdateOwnerAndAssignPok(ownerName, owner, pokemonName);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
        [HttpDelete("DeleteOnwer")]
        public async Task<IActionResult> DeleteOwner(string ownerName )
        {
            await _repo.DeleteOwner(ownerName);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
    }
}
