using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features.Song;

public interface IGetAllSongsQuery
{
    Task<IEnumerable<SongMinimalDto>> ExecuteAsync();
}

public class GetAllSongsQuery : IGetAllSongsQuery
{
    private readonly ILogger<GetAllSongsQuery> _logger;
    private readonly NplayDbContext _context;

    public GetAllSongsQuery(ILogger<GetAllSongsQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IEnumerable<SongMinimalDto>> ExecuteAsync()
    {
        try
        {
            var songQuery = _context.Songs.Where(s => s.Approved);
            var songList = await (songQuery.Select(s => new SongMinimalDto
            {
                Id = s.Id,
                Title = s.Title,
                Artist = s.Artist,
            })).ToListAsync();
        
            return songList;
        }

        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occured during GetAllSongsQuery");
            throw;
        }
    }
}

