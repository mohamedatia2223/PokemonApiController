using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;
using PokemonReviewApp.InterFace.Repo;
using PokemonReviewApp.Repo;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepo _repo;

        public PokemonController(IPokemonRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokemons()
        {
            var pokemons = await _repo.GetAllPokemons();
            return Ok(pokemons);
        }

        [HttpGet("getPokemonByName/{pokeName}")]
        public async Task<IActionResult> GetPokemonByName(string pokeName)
        {
            if (!await _repo.PokemonExist(pokeName))
                return NotFound($"No Pokémon named '{pokeName}' found.");

            var pokeDto = await _repo.GetPokemonByName(pokeName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokeDto);
        }
        [HttpGet("FilterPokemonByCat")]
        public async Task<IActionResult> FilterPokemonByCat()
        {
            var c = await _repo.FilterPokemon();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(c);
        }


        [HttpPost("AddPokemon")]
        public async Task<IActionResult> AddPokemon([FromForm] PokemonDTO pokemon)
        {
            await _repo.AddPokemon(pokemon);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
        [HttpPut("UpdatePokemon")]
        public async Task<IActionResult> UpdatePokemon(string name, [FromForm] PokemonDTO pokemon) 
        {
            await _repo.UpdatePokemon(name, pokemon);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
        [HttpDelete("DeletePokemon/pokemon")]
        public async Task<IActionResult> DeletePokemon(string pokemon) 
        {
            await _repo.DeletePokemon(pokemon);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok() ;
        }

    }
}
