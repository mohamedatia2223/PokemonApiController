using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.Model
{
    [Index(nameof(OwnerName))]
    public class Owner
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required,MaxLength(200)]
        public required string OwnerName { get; set; }
        [Required, MaxLength(200)]
        public string? GYM { get; set; }
        [Required, MaxLength(200)]
        public string? Country { get; set; }
        public Guid PokemonId { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }

    }
}
