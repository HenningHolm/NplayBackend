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
        private readonly IGetSimpleChordsListQuery _getBasicChordsListQuery;
        private readonly ISearchSimpleChordsQuery _searchBasicChordsQuery;
        private readonly IApproveSimpleChordsCommand _approveSimpleChordsCommand;

        public ChordsController(IGetSimpleChordsListQuery getBasicChordsListQuery, ISearchSimpleChordsQuery searchBasicChordsQuery, IApproveSimpleChordsCommand approveSimpleChordsCommand)
        {
            _getBasicChordsListQuery = getBasicChordsListQuery;
            _searchBasicChordsQuery = searchBasicChordsQuery;
            _approveSimpleChordsCommand = approveSimpleChordsCommand;
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

        //legg inn et ende punkt for å hente ikke godkjente akkorder, med litt extra info.


        [HttpGet("approve/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<string>>> ApproveSimpleChords(Guid id)
        {
            try
            {
                var results = await _approveSimpleChordsCommand.ExecuteAsync(id);
                if (results == null)
                {
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message);
            }
        }
    }
}
