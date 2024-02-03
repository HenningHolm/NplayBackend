using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features.Song;


public interface IGetSongQuery
{
    Task<SongDto> ExecuteAsync(string id);
}

public class GetSongQuery : IGetSongQuery
{
    private readonly ILogger<GetSongQuery> _logger;
    private readonly NplayDbContext _context;

    public GetSongQuery(ILogger<GetSongQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<SongDto> ExecuteAsync(string id)
    {
        try
        {
            //var song = await _context.Songs.FirstOrDefaultAsync(s => s.Id == id);

            var song = new SongDto
            {
                Id = "1",
                Name = "SongName",
                Artist = "ArtistName",
                Published = 2021
            };
            if (song == null)
            {
                return null;
            }
            return new SongDto { Artist = song.Artist, Name = song.Name, Published = song.Published, Id = song.Id };
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occured during GetOverviewNoteQuery");
            throw;
        }
    }

}