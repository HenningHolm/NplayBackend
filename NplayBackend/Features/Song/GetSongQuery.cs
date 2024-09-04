using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features.Song;


public interface IGetSongQuery
{
    Task<SongMinimalDto?> ExecuteAsync(Guid id);
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
    public async Task<SongMinimalDto?> ExecuteAsync(Guid id)
    {
        try
        {
            var song = await _context.Songs.FirstOrDefaultAsync(s => s.Id == id);
            
            if (song == null)
            {
                return null;
            }
            return new SongMinimalDto { Id = song.Id, Artist = song.Artist, Title = song.Title};
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occured during GetSongQuery");
            throw;
        }
    }

}