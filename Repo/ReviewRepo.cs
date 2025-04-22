using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;
using PokemonReviewApp.InterFace.Repo;

namespace PokemonReviewApp.Repo
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;

        public ReviewRepo(AppDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task CreateReview(ReviewDTO reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _db.Reviews.AddAsync(review);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteReview(string reviewName)
        {
            var review = await _db.Reviews
                .FirstOrDefaultAsync(r => r.Title == reviewName);

            if (review != null)
            {
                _db.Reviews.Remove(review);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteReviews(List<string> reviewNames)
        {
            var reviews = await _db.Reviews
                .Where(r => reviewNames.Contains(r.Title))
                .ToListAsync();

            _db.Reviews.RemoveRange(reviews);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReviewDTO>> GetAllReviews()
        {
            var reviews = await _db.Reviews
                .Include(r => r.reviewer)
                .Include(r => r.pokemon)
                .ToListAsync();

            return _mapper.Map<List<ReviewDTO>>(reviews);
        }

        public async Task<ReviewDTO> GetReviewByName(string name)
        {
            var review = await _db.Reviews
                .Include(r => r.reviewer)
                .Include(r => r.pokemon)
                .FirstOrDefaultAsync(r => r.Title == name);

            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<List<ReviewDTO>> GetReviewsOfAPokemon(string pokemonName)
        {
            var reviews = await _db.Reviews
                .Include(r => r.pokemon)
                .Include(r => r.reviewer)
                .Where(r => r.pokemon.PokemonName == pokemonName)
                .ToListAsync();

            return _mapper.Map<List<ReviewDTO>>(reviews);
        }

        public async Task<bool> ReviewExists(string reviewName)
        {
            return await _db.Reviews.AnyAsync(r => r.Title == reviewName);
        }

        public async Task UpdateReview(string reviewName, ReviewDTO reviewDto)
        {
            var existingReview = await _db.Reviews
                .Include(r => r.reviewer)
                .Include(r => r.pokemon)
                .FirstOrDefaultAsync(r => r.Title == reviewName);

            if (existingReview != null)
            {
                _mapper.Map(reviewDto, existingReview);
                await _db.SaveChangesAsync();
            }
        }
    }
}