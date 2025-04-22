using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.Model
{
    [Index(nameof(FirstName))]
    public class Reviewer
    {
        [Required]
        public Guid ReviewerId { get; set; }
        [Required,MaxLength(200)]
        public required string FirstName { get; set; }
        [Required,MaxLength(200)]
        public required string LastName { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
