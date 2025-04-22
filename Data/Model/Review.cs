using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.Model
{
    [Index(nameof(Title))]
    public class Review
    {
        [Required]
        public Guid ReviewId { get; set; }
        [Required,MaxLength(200)]
        public required string Title { get; set; }
        [Required,MaxLength(200)]
        public required string Text { get; set; }
        public Guid pokemonId { get; set; }
        public Guid reviewerId { get; set; }
        public Pokemon pokemon  { get; set; }
        public Reviewer reviewer { get; set; }

    }
}
