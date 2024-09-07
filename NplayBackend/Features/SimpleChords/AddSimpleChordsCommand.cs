using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Data.Entities;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features;

public interface IAddSimpleChordsCommand
{
    Task<bool> ExecuteAsync(Guid songId, SimpleChordsDto simpleChordsDto);
}

public class AddSimpleChordsCommand : IAddSimpleChordsCommand
{
    private readonly ILogger<AddSimpleChordsCommand> _logger;
    private readonly NplayDbContext _context;

    public AddSimpleChordsCommand(ILogger<AddSimpleChordsCommand> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> ExecuteAsync(Guid songId, SimpleChordsDto simpleChordsDto)
    {
        try
        {

            var song = await _context.Songs
                .FirstOrDefaultAsync(s => s.Id == songId);

            if (song == null)
            {
                _logger.LogWarning($"Song with ID {songId} not found.");
                return false;
            }


            var simpleChordsEntity = new SimpleChords
            {
                Id = Guid.NewGuid(), 
                Intro = simpleChordsDto.Intro,
                Verse = simpleChordsDto.Verse,
                VerseEnd = simpleChordsDto.VerseEnd,
                PreChorus = simpleChordsDto.PreChorus,
                Chorus = simpleChordsDto.Chorus,
                ChorusEnd = simpleChordsDto.ChorusEnd,
                Bridge = simpleChordsDto.Bridge,
                Outro = simpleChordsDto.Outro,
                Approved = false,
                Version = 0,
                SongId = song.Id,
                Song = song 
            };

            await _context.SimpleChords.AddAsync(simpleChordsEntity);

            await _context.SaveChangesAsync();

            return true; 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding simple chords.");
            throw; 
        }
    }
}
