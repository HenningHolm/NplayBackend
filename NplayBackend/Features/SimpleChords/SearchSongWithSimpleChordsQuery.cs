using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features;

public interface ISearchSongWithSimpleChordsQuery
{
    Task<IEnumerable<SongWithSimpleChordsMiniDto>> ExecuteAsync(string searchString);
}

public class SearchSongWithSimpleChordsQuery : ISearchSongWithSimpleChordsQuery
{
    private readonly ILogger<SearchSongWithSimpleChordsQuery> _logger;
    private readonly NplayDbContext _context;

    public SearchSongWithSimpleChordsQuery(ILogger<SearchSongWithSimpleChordsQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<SongWithSimpleChordsMiniDto>> ExecuteAsync(string searchString)
    {
        try
        {
            // Handle the case where searchString is null or whitespace
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return new List<SongWithSimpleChordsMiniDto>();
            }

            // Convert search string to lowercase to ensure case-insensitive search
            searchString = searchString.ToLower();

            // Query to fetch songs with approved status and non-null/non-empty ChromaArray
            var chordsSongsQuery = _context.Songs
                .Where(s => s.Approved
                            && (EF.Functions.Like(s.Title.ToLower() ?? "", $"%{searchString}%")
                                || EF.Functions.Like(s.Artist.ToLower() ?? "", $"%{searchString}%"))
                            && s.ChromaArray != null && s.ChromaArray.Any());

            // Select the desired fields into SongWithSimpleChordsMiniDto
            var chordsSongsList = await chordsSongsQuery
                .Select(s => new SongWithSimpleChordsMiniDto
                {
                    SongId = s.Id,
                    Title = s.Title,
                    Artist = s.Artist,
                    ChromaArray = s.ChromaArray!,
                    SimpleChordsId = s.PrimarySimpleChordsId ?? Guid.Empty // Ensure a valid Guid is returned
                })
                .ToListAsync();

            return chordsSongsList;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occurred during SearchSimpleChordsQuery: {e.Message}");
            throw;
        }
    }
}