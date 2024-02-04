using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NplayBackend.Features.Song;
using NplayBackend.Models.Dto;

namespace NplayBackend.Controllers.Api;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly ILogger<SongController> _logger;
    private readonly ISetSongCommand _setSongCommand;
    private readonly IGetSongQuery _getSongQuery;

    public SongController(ILogger<SongController> logger, IGetSongQuery getSongQuery, ISetSongCommand setSongCommand)
    {
        _logger = logger;
        _getSongQuery = getSongQuery;
        _setSongCommand = setSongCommand;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SongDto>> GetSong(string id)
    
    {
        // get user info
        var user = User;

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
    [HttpPost]
    public async Task<ActionResult> SetNote(SongDto song)
    {
        try
        {
            await _setSongCommand.ExecuteAsync(song);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

