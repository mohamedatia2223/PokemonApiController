using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.InterFace.Repo;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepo _repo;

        public ReviewerController(IReviewerRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviewers()
        {
            var reviewers = await _repo.GetAllReviewers();
            return Ok(reviewers);
        }

        [HttpGet("GetReviewerByName")]
        public async Task<IActionResult> GetReviewerByName(string firstName, string lastName)
        {
            if (!await _repo.ReviewerExists(firstName, lastName))
                return NotFound($"No reviewer found with name {firstName} {lastName}.");

            var reviewer = await _repo.GetReviewersByName(firstName, lastName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("GetReviewsByReviewer")]
        public async Task<IActionResult> GetReviewsByReviewer(string firstName, string lastName)
        {
            var reviews = await _repo.GetReviewesByReviewer(firstName, lastName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost("AddReviewer")]
        public async Task<IActionResult> AddReviewer([FromForm] ReviewerDTO reviewer)
        {
            await _repo.AddReviewer(reviewer);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpPut("UpdateReviewer")]
        public async Task<IActionResult> UpdateReviewer(string firstName, string lastName, [FromForm] ReviewerDTO reviewer)
        {
            await _repo.UpdateReviewer(firstName, lastName, reviewer);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("DeleteReviewer")]
        public async Task<IActionResult> DeleteReviewer(string firstName, string lastName)
        {
            await _repo.DeleteReviewer(firstName, lastName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
