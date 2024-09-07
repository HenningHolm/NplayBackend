using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;
using NplayBackend.Models.Shared;

namespace NplayBackend.Features;

public interface IGetAllSongWithSimpleChordsQuery
{
    Task<PaginatedResult<SongWithSimpleChordsMiniDto>> ExecuteAsync(int pageNumber, int pageSize);
}

public class GetAllSongWithSimpleChordsQuery : IGetAllSongWithSimpleChordsQuery
{
    private readonly ILogger<GetAllSongWithSimpleChordsQuery> _logger;
    private readonly NplayDbContext _context;

    public GetAllSongWithSimpleChordsQuery(ILogger<GetAllSongWithSimpleChordsQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<PaginatedResult<SongWithSimpleChordsMiniDto>> ExecuteAsync(int pageNumber, int pageSize)
    {
        try
        {
            // Count the total number of approved songs with a non-null ChromaArray and SimpleChordsId
            var totalApprovedChords = await _context.Songs
                .Where(s => s.ChromaArray != null && s.ChromaArray.Any() && s.PrimarySimpleChordsId != null)
                .CountAsync();

            // Perform a paginated query where ChromaArray and SimpleChordsId are not null
            var songsQuery = _context.Songs
                .Where(s => s.Approved && s.ChromaArray != null && s.ChromaArray.Any() && s.PrimarySimpleChordsId != null)
                .OrderBy(s => s.Title) // Order by title for readability
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // Project the results into SongWithSimpleChordsMiniDto
            var songsList = await songsQuery
                .Select(s => new SongWithSimpleChordsMiniDto
                {
                    SongId = s.Id,
                    Title = s.Title,
                    Artist = s.Artist,
                    ChromaArray = s.ChromaArray!, // ChromaArray is assumed to be non-null at this point
                    SimpleChordsId = s.PrimarySimpleChordsId ?? Guid.Empty // Handle null SimpleChordsId by returning an empty Guid
                })
                .ToListAsync();

            // Return the paginated results
            return new PaginatedResult<SongWithSimpleChordsMiniDto>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalApprovedChords, // Set the TotalCount
                Results = songsList
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occurred during GetSongWithSimpleChordsListQuery: {e.Message}");
            throw;
        }
    }
}