using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.Model
{
    [Index(nameof(PokemonName))]
    public class Pokemon
    {
        [Required]
        public Guid PokemonId { get; set; }
        [Required,MaxLength(200)]
        public required string PokemonName { get; set; }
        [Required, MaxLength(200)]
        public DateTime BirthDate { get; set; }
        [Required, MaxLength(200)]
        public string Categories { get; set; }
        public ICollection<Owner> Owners { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
