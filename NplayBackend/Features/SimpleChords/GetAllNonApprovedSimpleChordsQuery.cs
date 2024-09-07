using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;

namespace NplayBackend.Features;

public interface IGetAllNonApprovedSimpleChordsQuery
{
    Task<IEnumerable<SongWithNonApprovedSimpleChordsMiniDto>> ExecuteAsync();
}

public class GetAllNonApprovedSimpleChordsQuery : IGetAllNonApprovedSimpleChordsQuery
{
    private readonly ILogger<GetAllNonApprovedSimpleChordsQuery> _logger;
    private readonly NplayDbContext _context;

    public GetAllNonApprovedSimpleChordsQuery(ILogger<GetAllNonApprovedSimpleChordsQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<SongWithNonApprovedSimpleChordsMiniDto>> ExecuteAsync()
    {
        try
        {
            // Query to find all non-approved simple chords and their associated songs
            var result = await _context.SimpleChords
                .Where(sc => !sc.Approved) // Fetch all non-approved SimpleChords
                .Select(sc => new SongWithNonApprovedSimpleChordsMiniDto
                {
                    SongId = sc.SongId, // Assuming there's a SongId in SimpleChords
                    Title = sc.Song.Title, // Navigation to Song for the title
                    Artist = sc.Song.Artist, // Navigation to Song for the artist
                    SimpleChordsId = sc.Id
                })
                .ToListAsync();

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching non-approved simple chords.");
            throw;
        }
    }
}
