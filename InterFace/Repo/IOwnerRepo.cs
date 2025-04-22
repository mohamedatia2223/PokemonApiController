using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;

namespace PokemonReviewApp.InterFace.Repo
{
    public interface IOwnerRepo
    {
        public Task<List<OwnerDTO>> GetAllOwners();
        public Task<OwnerDTO> GetOwnerByName(string name);
        public Task<bool> OnwerExist (string name);
        public Task<OwnerDTO> GetOwnerByPokemon(string pokemon);
        public Task UpdateOwnerAndAssignPok(string name, OwnerDTO ownDTO, string pokName);
        public Task AddOwner(OwnerDTO ownerDTO);
        public Task DeleteOwner(string id);
    }
}
