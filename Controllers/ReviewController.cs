using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data.DTOs;
using PokemonReviewApp.InterFace.Repo;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepo _repo;

        public ReviewController(IReviewRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _repo.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet("GetReviewByName")]
        public async Task<IActionResult> GetReviewByName(string reviewName)
        {
            if (!await _repo.ReviewExists(reviewName))
                return NotFound($"No review found with title '{reviewName}'.");

            var review = await _repo.GetReviewByName(reviewName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpGet("GetReviewsOfPokemon")]
        public async Task<IActionResult> GetReviewsOfPokemon(string pokemonName)
        {
            var reviews = await _repo.GetReviewsOfAPokemon(pokemonName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromForm] ReviewDTO reviewDto)
        {
            await _repo.CreateReview(reviewDto);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReview(string reviewName, [FromForm] ReviewDTO reviewDto)
        {
            await _repo.UpdateReview(reviewName, reviewDto);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("DeleteReview")]
        public async Task<IActionResult> DeleteReview(string reviewName)
        {
            await _repo.DeleteReview(reviewName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("DeleteMultipleReviews")]
        public async Task<IActionResult> DeleteMultipleReviews([FromQuery] List<string> reviewNames)
        {
            await _repo.DeleteReviews(reviewNames);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
