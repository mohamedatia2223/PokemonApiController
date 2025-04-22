using PokemonReviewApp.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.DTOs
{
    public class OwnerDTO
    {
        public required string OwnerName { get; set; }
        public string? GYM { get; set; }
        public string? Country { get; set; }

    }
}
