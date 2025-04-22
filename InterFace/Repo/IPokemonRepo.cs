using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;

namespace PokemonReviewApp.InterFace.Repo
{
    public interface IPokemonRepo
    {
        public Task<List<PokemonDTO>>GetAllPokemons();
        public Task<PokemonDTO> GetPokemonByName(string pokemonName);
        public Task<bool> PokemonExist (string pokeName);
        public Task<List<PokemonDTO>> FilterPokemon();
        public Task AddPokemon(PokemonDTO pokemonDTO);
        public Task UpdatePokemon(string pokemonName, PokemonDTO pokemonDTO);
        public Task DeletePokemon(string pokemonName);

    }
}
