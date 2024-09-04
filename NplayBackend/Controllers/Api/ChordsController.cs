using Microsoft.AspNetCore.Mvc;
using NplayBackend.Features.Chords;
using NplayBackend.Models.Dto;
using NplayBackend.Models.Shared;

namespace NplayBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChordsController : ControllerBase
    {
        private readonly IGetBasicChordsListQuery _getBasicChordsListQuery;
        private readonly ISearchBasicChordsQuery _searchBasicChordsQuery;

        public ChordsController(IGetBasicChordsListQuery getBasicChordsListQuery, ISearchBasicChordsQuery searchBasicChordsQuery)
        {
            _getBasicChordsListQuery = getBasicChordsListQuery;
            _searchBasicChordsQuery = searchBasicChordsQuery;
        }

        // Endpoint for all approved basic chords by pagination
        [HttpGet("chords-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaginatedResult<ChordsMinimalDto>>> GetBasicChordsList(int pageNumber = 1, int pageSize = 10)
        {
            // Validate params
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }
            try
            {
                var result = await _getBasicChordsListQuery.ExecuteAsync(pageNumber, pageSize);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message);
            }
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ChordsMinimalDto>>> SearchBasicChords([FromQuery] string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return BadRequest("Search string cannot be empty.");
            }
            try
            {
                var results = await _searchBasicChordsQuery.ExecuteAsync(searchString);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message );
            }
        }
    }
}
