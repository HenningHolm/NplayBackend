using NplayBackend.Data;
using NplayBackend.Data.Entities;
using NplayBackend.Models.Dto;
namespace NplayBackend.Features;

public interface IAddSongCommand
{
    Task ExecuteAsync(SongDto song);
}


public class AddSongCommand : IAddSongCommand
{
    private readonly ILogger<AddSongCommand> _logger;
    private readonly NplayDbContext _context;

    public AddSongCommand(ILogger<AddSongCommand> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task ExecuteAsync(SongDto songDto)
    {
        try
        {
            var songEntity = new Song
            {
                Id = Guid.NewGuid(), // Necessary?
                Title = songDto.Title,
                Artist = songDto.Artist,
                Chroma = songDto.Chroma,
                Scale = songDto.Scale,
                BPM = songDto.BPM,
                Difficulty = songDto.Difficulty,
                Recognitions = songDto.Recognitions, 
                SpotifyCode = songDto.SpotifyCode,
                YoutubeCode = songDto.YoutubeCode,
                Approved = true // Consider changing to false and adding an approval process later
            };

            await _context.Songs.AddAsync(songEntity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a new song.");
            throw;
        }
    }
}

