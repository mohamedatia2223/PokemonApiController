using PokemonReviewApp.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.DTOs
{
    public class PokemonDTO
    {
        public required string PokemonName { get; set; }
        public string Categories { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
