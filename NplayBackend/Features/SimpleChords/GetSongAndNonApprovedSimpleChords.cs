using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features;

public interface IGetSongAndNonApprovedSimpleChords
{
    Task<SongWithSimpleChordsDto> ExecuteAsync(Guid simpleChordsId);
}

public class GetSongAndNonApprovedSimpleChords : IGetSongAndNonApprovedSimpleChords
{
    private readonly ILogger<GetSongAndNonApprovedSimpleChords> _logger;
    private readonly NplayDbContext _context;

    public GetSongAndNonApprovedSimpleChords(ILogger<GetSongAndNonApprovedSimpleChords> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<SongWithSimpleChordsDto> ExecuteAsync(Guid simpleChordsId)
    {
        // Hent SimpleChords basert på simpleChordsId
        var simpleChords = await _context.SimpleChords
            .Include(sc => sc.Song) // Henter den tilknyttede Song
            .FirstOrDefaultAsync(sc => sc.Id == simpleChordsId && !sc.Approved); // Finner ikke-godkjente akkorder

        if (simpleChords == null)
        {
            throw new KeyNotFoundException("SimpleChords not found or already approved.");
        }

        // Mapper Song data til SongDto
        var songDto = new SongDto
        {
            Id = simpleChords.Song.Id,
            Title = simpleChords.Song.Title,
            Artist = simpleChords.Song.Artist,
            Chroma = simpleChords.Song.Chroma,
            Scale = simpleChords.Song.Scale,
            BPM = simpleChords.Song.BPM,
            Difficulty = simpleChords.Song.Difficulty,
            Recognitions = simpleChords.Song.Recognitions,
            SpotifyCode = simpleChords.Song.SpotifyCode,
            YoutubeCode = simpleChords.Song.YoutubeCode,
        };

        // Mapper SimpleChords data til SimpleChordsDto
        var simpleChordsDto = new SimpleChordsDto
        {
            Id = simpleChords.Id,
            Intro = simpleChords.Intro,
            Verse = simpleChords.Verse,
            VerseEnd = simpleChords.VerseEnd,
            PreChorus = simpleChords.PreChorus,
            Chorus = simpleChords.Chorus,
            ChorusEnd = simpleChords.ChorusEnd,
            Bridge = simpleChords.Bridge,
            Outro = simpleChords.Outro,
        };

        // Returner kombinasjonen av Song og SimpleChords
        return new SongWithSimpleChordsDto
        {
            Song = songDto,
            SimpleChords = simpleChordsDto
        };
    }
}