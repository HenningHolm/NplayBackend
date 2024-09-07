using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features;


public interface IGetSongQuery
{
    Task<SongDto?> ExecuteAsync(Guid id);
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
    public async Task<SongDto?> ExecuteAsync(Guid id)
    {
        try
        {
            var song = await _context.Songs
                .FirstOrDefaultAsync(s => s.Id == id);

            if (song == null)
            {
                _logger.LogWarning($"Song with id {id} not found.");
                return null;
            }

            var songDto = new SongDto
            {
                Id = song.Id,
                Title = song.Title,
                Artist = song.Artist,
                Chroma = song.Chroma,
                Scale = song.Scale,
                BPM = song.BPM,
                Difficulty = song.Difficulty,
                Recognitions = song.Recognitions,
                SpotifyCode = song.SpotifyCode,
                YoutubeCode = song.YoutubeCode,
            };

            return songDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the song.");
            throw;
        }
    }
}