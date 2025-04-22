using PokemonReviewApp.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Data.DTOs
{
    public class ReviewDTO
    {
        public required string Title { get; set; }
        public required string Text { get; set; }

    }
}
