using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features;

    public interface IGetSongAndPrimarySimpleChordsQuery
{
    Task<SongWithSimpleChordsDto> ExecuteAsync(Guid songId);
}


public class GetSongAndPrimarySimpleChordsQuery : IGetSongAndPrimarySimpleChordsQuery //maybe get alterative chordsId, if exists
{
    private readonly ILogger<GetAllSongWithSimpleChordsQuery> _logger;
    private readonly NplayDbContext _context;
    public GetSongAndPrimarySimpleChordsQuery(ILogger<GetAllSongWithSimpleChordsQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<SongWithSimpleChordsDto> ExecuteAsync(Guid songId)
    {
        // Hent sangen basert på songId
        var song = await _context.Songs
            .FirstOrDefaultAsync(s => s.Id == songId && s.Approved);

        if (song == null)
        {
            throw new KeyNotFoundException("Song not found or not approved.");
        }

        // Hent primær SimpleChords basert på SimpleChordsId
        var simpleChords = await _context.SimpleChords
            .FirstOrDefaultAsync(sc => sc.Id == song.PrimarySimpleChordsId && sc.Approved);

        if (simpleChords == null)
        {
            throw new KeyNotFoundException("Primary SimpleChords not found or not approved.");
        }

        // Mapper resultatene til DTO-er
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

