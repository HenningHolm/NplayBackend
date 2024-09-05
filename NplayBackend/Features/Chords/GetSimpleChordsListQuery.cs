using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Data.Entities;
using NplayBackend.Models.Dto;
using NplayBackend.Models.Shared;

namespace NplayBackend.Features.Chords;

    public interface IGetSimpleChordsListQuery
{
    Task<PaginatedResult<ChordsMinimalDto>> ExecuteAsync(int pageNumber, int pageSize);
}

public class GetSimpleChordsListQuery : IGetSimpleChordsListQuery
{
    private readonly ILogger<GetSimpleChordsListQuery> _logger;
    private readonly NplayDbContext _context;

    public GetSimpleChordsListQuery(ILogger<GetSimpleChordsListQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<PaginatedResult<ChordsMinimalDto>> ExecuteAsync(int pageNumber, int pageSize)
    {
        try
        {
            // Tell antall godkjente akkorder der ChromaArray ikke er null og inneholder elementer
            var totalApprovedChords = await _context.SimpleChords
                .Where(c => c.Approved && c.Song.ChromaArray != null && c.Song.ChromaArray.Any())
                .CountAsync();

            // Utfør paginert spørring der ChromaArray ikke er null og inneholder elementer
            var chordsQuery = _context.SimpleChords
                .Where(c => c.Approved && c.Song.ChromaArray != null && c.Song.ChromaArray.Any())
                .OrderBy(c => c.Song.Title) // Sorter etter tittel for lesbarhet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // Projiser resultatene til ChordsMinimalDto
            var chordsList = await chordsQuery
                .Select(c => new ChordsMinimalDto
                {
                    SongId = c.SongId,
                    Title = c.Song.Title,
                    Artist = c.Song.Artist,
                    ChromaArray = c.Song.ChromaArray // Assuming ChromaArray is on Song
                })
                .ToListAsync();

            // Returner paginerte resultater
            return new PaginatedResult<ChordsMinimalDto>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalApprovedChords,  // Setter TotalCount
                Results = chordsList
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occurred during GetBasicChordsListQuery");
            throw;
        }
    }
}
