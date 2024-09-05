using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features.Chords;
public interface ISearchSimpleChordsQuery
{
    Task<IEnumerable<ChordsMinimalDto>> ExecuteAsync(string searchString);
}

public class SearchSimpleChordsQuery : ISearchSimpleChordsQuery
{
    private readonly ILogger<SearchSimpleChordsQuery> _logger;
    private readonly NplayDbContext _context;

    public SearchSimpleChordsQuery(ILogger<SearchSimpleChordsQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<ChordsMinimalDto>> ExecuteAsync(string searchString)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return new List<ChordsMinimalDto>();
            }

            searchString = searchString.ToLower();

            var chordsSongsQuery = _context.Songs
                .Where(s => s.Approved
                            && (EF.Functions.Like(s.Title.ToLower() ?? "", $"%{searchString}%")
                                || EF.Functions.Like(s.Artist.ToLower() ?? "", $"%{searchString}%"))
                            && s.ChromaArray != null && s.ChromaArray.Any());

            var chordsSongsList = await chordsSongsQuery
                .Select(s => new ChordsMinimalDto
                {
                    SongId = s.Id,
                    Title = s.Title,
                    Artist = s.Artist,
                    ChromaArray = s.ChromaArray
                })
                .ToListAsync();

            return chordsSongsList;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occurred during SearchBasicChordsQuery");
            throw;
        }
    }
}

