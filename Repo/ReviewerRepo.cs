using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.Data.Model;
using PokemonReviewApp.InterFace.Repo;

namespace PokemonReviewApp.Repo
{
    public class ReviewerRepo : IReviewerRepo
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;
        public ReviewerRepo(IMapper mapper,AppDBContext db)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task AddReviewer(ReviewerDTO reviewerDTO)
        {
            var reviewer = _mapper.Map<Reviewer>(reviewerDTO);
            await _db.Reviewers.AddAsync(reviewer);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteReviewer(string firstName, string lastName)
        {
            var c = await _db.Reviewers.SingleOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);
            _db.Remove(c);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReviewerDTO>> GetAllReviewers()
        {
            var Revs = await _db.Reviewers.ToListAsync();
            return _mapper.Map<List<ReviewerDTO>>(Revs);

        }

        public async Task<ReviewerDTO> GetReviewersByName(string firstName,string lastName)
        {
            var rev =await _db.Reviewers.SingleOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);
            return _mapper.Map<ReviewerDTO>(rev);
        }

        public async Task<List<ReviewDTO>> GetReviewesByReviewer(string firstName,string lastName)
        {
            var revs = await _db.Reviews
                .Include(a => a.reviewer)
                .Where(a => a.reviewer.FirstName == firstName && a.reviewer.LastName == lastName)
                .ToListAsync();
            return _mapper.Map<List<ReviewDTO>>(revs);
        }

        public async Task<bool> ReviewerExists(string firstName, string lastName)
        {
            return await _db.Reviewers.AnyAsync(a => a.FirstName == firstName && a.LastName == lastName);
        }

        public async Task UpdateReviewer(string firstName, string lastName, ReviewerDTO reviewer)
        {
            var existingreviewer = await _db.Reviewers.FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);
            if (existingreviewer != null)
            {
                _mapper.Map(reviewer, existingreviewer);
                await _db.SaveChangesAsync();
            }
        }

    }
}
