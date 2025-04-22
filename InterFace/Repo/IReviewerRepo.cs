using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;

namespace PokemonReviewApp.InterFace.Repo
{
    public interface IReviewerRepo
    {
        public Task<List<ReviewerDTO>> GetAllReviewers();
        public Task<ReviewerDTO> GetReviewersByName(string firstName, string lastName);
        public Task<bool> ReviewerExists(string firstName, string lastName);
        public Task<List<ReviewDTO>> GetReviewesByReviewer(string firstName,string lastName);
        public Task UpdateReviewer(string firstName, string lastName, ReviewerDTO reviewerDTO);
        public Task DeleteReviewer(string FirstName,string LastName);
        public Task AddReviewer(ReviewerDTO reviewerDTO);
    }
}
