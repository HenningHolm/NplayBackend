using Microsoft.AspNetCore.Mvc;
using NplayBackend.Features;
using NplayBackend.Models.Dto;
using NplayBackend.Models.Shared;

namespace NplayBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimpleChordsController : ControllerBase
    {
        private readonly IGetAllSongWithSimpleChordsQuery _getAllSongWithSimpleChordsQuery;
        private readonly ISearchSongWithSimpleChordsQuery _searchSongWithSimpleChordsQuery;
        private readonly IAddSimpleChordsCommand _addSimpleChordsCommand;
        private readonly IApprovePrimarySimpleChordsCommand _approvePrimarySimpleChordsCommand;
        private readonly IGetSongAndPrimarySimpleChordsQuery _getSongAndPrimarySimpleChordsQuery;
        private readonly IGetAllNonApprovedSimpleChordsQuery _getAllNonApprovedSimpleChordsQuery;
        private readonly IGetSongAndNonApprovedSimpleChords _getSongAndNonApprovedSimpleChordsQuery;

        public SimpleChordsController(IGetSongAndPrimarySimpleChordsQuery getSongAndPrimarySimpleChordsQuery, IApprovePrimarySimpleChordsCommand approvePrimarySimpleChordsCommand, ISearchSongWithSimpleChordsQuery searchSongWithSimpleChordsQuery, IGetAllSongWithSimpleChordsQuery getAllSongWithSimpleChordsQuery, IGetAllNonApprovedSimpleChordsQuery getAllNonApprovedSimpleChordsQuery, IGetSongAndNonApprovedSimpleChords getSongAndNonApprovedSimpleChordsQuery, IAddSimpleChordsCommand addSimpleChordsCommand)
        {
            _getSongAndPrimarySimpleChordsQuery = getSongAndPrimarySimpleChordsQuery;
            _approvePrimarySimpleChordsCommand = approvePrimarySimpleChordsCommand;
            _searchSongWithSimpleChordsQuery = searchSongWithSimpleChordsQuery;
            _getAllSongWithSimpleChordsQuery = getAllSongWithSimpleChordsQuery;
            _getAllNonApprovedSimpleChordsQuery = getAllNonApprovedSimpleChordsQuery;
            _getSongAndNonApprovedSimpleChordsQuery = getSongAndNonApprovedSimpleChordsQuery;
            _addSimpleChordsCommand = addSimpleChordsCommand;
        }


        // Endpoint for all approved basic chords by pagination
        [HttpGet("songs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaginatedResult<SongWithSimpleChordsMiniDto>>> GetAllSongsWithSimpleChords(int pageNumber = 1, int pageSize = 10)
        {
            // Validate params
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }
            try
            {
                var result = await _getAllSongWithSimpleChordsQuery.ExecuteAsync(pageNumber, pageSize);

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
        public async Task<ActionResult<IEnumerable<SongWithSimpleChordsMiniDto>>> SearchSongWithSimpleChords([FromQuery] string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return BadRequest("Search string cannot be empty.");
            }
            try
            {
                var results = await _searchSongWithSimpleChordsQuery.ExecuteAsync(searchString);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message );
            }
        }

        [HttpPost("add-simplechords/{songId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddSimpleChords(Guid songId, [FromBody] SimpleChordsDto simpleChordsDto)
        {
            try
            {
                var result = await _addSimpleChordsCommand.ExecuteAsync(songId, simpleChordsDto);
                if (!result)
                {
                    return NotFound($"Song with ID {songId} not found.");
                }

                return Ok("Simple chords added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message);
            }
        }


        [HttpGet("song-and-primary/{songId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SongWithSimpleChordsDto>> GetSongWithPrimaryChords(Guid songId)
        {
            try
            {
                var result = await _getSongAndPrimarySimpleChordsQuery.ExecuteAsync(songId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message);
            }
        }



        // Endpoint for approving simple chords, return the chromaList of the song
        [HttpGet("approve-primary/{chordsId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<string>>> ApprovePrimarySimpleChords(Guid chordsId)
        {
            try
            {
                var results = await _approvePrimarySimpleChordsCommand.ExecuteAsync(chordsId);
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

        // Endpoint for fetching all non-approved simple chords
        [HttpGet("non-approved-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SongWithNonApprovedSimpleChordsMiniDto>>> GetNonApprovedSimpleChords()
        {
            try
            {
                var results = await _getAllNonApprovedSimpleChordsQuery.ExecuteAsync();

                if (results == null || !results.Any())
                {
                    return NotFound("No non-approved SimpleChords found.");
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message);
            }
        }

        [HttpGet("song-and-non-approved/{chordsId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SongWithSimpleChordsDto>> GetSongAndNonApprovedSimpleChords(Guid chordsId)
        {
            try
            {
                var result = await _getSongAndNonApprovedSimpleChordsQuery.ExecuteAsync(chordsId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors and return a 500 status code
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Error: " + ex.Message);
            }
        }

    }
}
