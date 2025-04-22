using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;

namespace PokemonReviewApp.InterFace.Repo
{
    public interface IReviewRepo
    {
        public Task<List<ReviewDTO>> GetAllReviews();
        public Task<ReviewDTO> GetReviewByName(string name);
        public Task<List<ReviewDTO>> GetReviewsOfAPokemon(string name);
        public Task<bool> ReviewExists(string name);
        public Task CreateReview(ReviewDTO review);
        public Task UpdateReview(string reviewName, ReviewDTO reviewDto);
        public Task DeleteReview(string reviewName);
        public Task DeleteReviews(List<string> reviews);
    }
}
