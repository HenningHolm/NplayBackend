using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NplayBackend.Features;
using NplayBackend.Models.Dto;

namespace NplayBackend.Controllers.Api;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly ILogger<SongController> _logger;
    private readonly IGetSongQuery _getSongQuery;
    private readonly IGetAllSongsQuery _getAllSongsQuery;

    public SongController(ILogger<SongController> logger, IGetSongQuery getSongQuery, IAddSongCommand setSongCommand, IGetAllSongsQuery getAllSongsQuery)
    {
        _logger = logger;
        _getSongQuery = getSongQuery;
        _getAllSongsQuery = getAllSongsQuery;
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SongMinimalDto>> GetSong(Guid id)
    {
        try
        {
            var song = await _getSongQuery.ExecuteAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<SongMinimalDto>>> GetAllSongs()
    {
        try
        {
            var song = await _getAllSongsQuery.ExecuteAsync();
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    //[HttpPost]
    //public async Task<ActionResult> SetNote(SongMinimalDto song)
    //{
    //    try
    //    {
    //        await _setSongCommand.ExecuteAsync(song);
    //        return Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}
}

