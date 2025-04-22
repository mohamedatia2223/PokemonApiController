using PokemonReviewApp.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.DTOs
{
    public class ReviewerDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

    }
}
