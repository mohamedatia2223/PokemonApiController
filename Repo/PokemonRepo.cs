using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;
using PokemonReviewApp.InterFace.Repo;

namespace PokemonReviewApp.Repo
{
    public class PokemonRepo : IPokemonRepo
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;
        public PokemonRepo(IMapper mapper,AppDBContext db)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task AddPokemon(PokemonDTO pokemonDTO)
        {
            var pok = _mapper.Map<Pokemon>(pokemonDTO);
            await _db.AddAsync(pok);
            await _db.SaveChangesAsync();
           
        }

        public async Task DeletePokemon(string pokemonName)
        {
            var pok = await _db.Pokemons.SingleOrDefaultAsync(a => a.PokemonName == pokemonName);
            if (pok == null)
                return; 

            _db.Remove(pok);
            await _db.SaveChangesAsync();
        }


        public async Task<List<PokemonDTO>> FilterPokemon()
        {
            var poks =await _db.Pokemons.OrderBy(a => a.Categories).ToListAsync();
            return _mapper.Map<List<PokemonDTO>>(poks);
           
        }

        public async Task<List<PokemonDTO>> GetAllPokemons()
        {
            var poks = await _db.Pokemons.ToListAsync();
            return _mapper.Map<List<PokemonDTO>>(poks);
        }

        public async Task<PokemonDTO> GetPokemonByName(string pokemonName)
        {
            var poke = await _db.Pokemons.SingleOrDefaultAsync(a => a.PokemonName == pokemonName);
            return poke == null ? null : _mapper.Map<PokemonDTO>(poke);  
        }

        public Task<bool> PokemonExist(string pokeName)
        {
            return _db.Pokemons.AnyAsync(a => a.PokemonName == pokeName);
        }

        public async Task UpdatePokemon(string pokemonName, PokemonDTO pokemonDTO)
        {
            var existingPokemon = await _db.Pokemons.FirstOrDefaultAsync(p => p.PokemonName == pokemonName);
            if (existingPokemon != null)
            {
                _mapper.Map(pokemonDTO, existingPokemon);
                await _db.SaveChangesAsync();
            }
        }

    }
}
