using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;
using PokemonReviewApp.InterFace.Repo;

namespace PokemonReviewApp.Repo
{
    public class OwnerRepo : IOwnerRepo
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;
        public OwnerRepo(AppDBContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;  
        }

        public async Task AddOwner(OwnerDTO ownerDto)
        {
           var owner = _mapper.Map<Owner>(ownerDto);
           await _db.Owners.AddAsync(owner);
           await _db.SaveChangesAsync();  
        }

        public async Task DeleteOwner(string name)
        {
            var c = await _db.Owners.SingleOrDefaultAsync(a => a.OwnerName == name);
            _db.Owners.Remove(c);
            await _db.SaveChangesAsync();
        }

        public async Task<List<OwnerDTO>> GetAllOwners()
        {
            var c = await _db.Owners.ToListAsync();
            return _mapper.Map<List<OwnerDTO>>(c);
            
        }


        public async Task<OwnerDTO> GetOwnerByName(string name)
        {
            var c =await _db.Owners.SingleOrDefaultAsync(a => a.OwnerName == name);
            return _mapper.Map<OwnerDTO>(c);

        }

        public async Task<OwnerDTO> GetOwnerByPokemon(string pokemonName)
        {
            var pokemon = await _db.Pokemons
                .Include(p => p.Owners) 
                .FirstOrDefaultAsync(p => p.PokemonName == pokemonName);

            if (pokemon == null || pokemon.Owners == null || !pokemon.Owners.Any())
                return null;


            return _mapper.Map<OwnerDTO>(pokemon.Owners.First());

        }

        public async Task<bool> OnwerExist(string name)
        {
            return await _db.Owners.AnyAsync(a => a.OwnerName == name);
        }

        public async Task UpdateOwnerAndAssignPok(string name, OwnerDTO ownDTO, string pokName)
        {
            var existingOwner = await _db.Owners.FirstOrDefaultAsync(p => p.OwnerName == name);
            if (existingOwner != null)
            {
                _mapper.Map(ownDTO, existingOwner);

                var pokemonId = await _db.Pokemons
                    .Where(p => p.PokemonName == pokName)
                    .Select(p => p.PokemonId)
                    .FirstOrDefaultAsync(); 

                existingOwner.PokemonId = pokemonId;

                await _db.SaveChangesAsync();
            }
        }
    }
}
