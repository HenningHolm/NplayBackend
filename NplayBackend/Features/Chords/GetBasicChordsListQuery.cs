using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Models.Dto;
using NplayBackend.Models.Shared;

namespace NplayBackend.Features.Chords;

    public interface IGetBasicChordsListQuery
{
    Task<PaginatedResult<ChordsMinimalDto>> ExecuteAsync(int pageNumber, int pageSize);
}

public class GetBasicChordsListQuery : IGetBasicChordsListQuery
{
    private readonly ILogger<GetBasicChordsListQuery> _logger;
    private readonly NplayDbContext _context;

    public GetBasicChordsListQuery(ILogger<GetBasicChordsListQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<PaginatedResult<ChordsMinimalDto>> ExecuteAsync(int pageNumber, int pageSize)
    {
        try
        {
            var totalApprovedChords = await _context.SimpleChords
                .Where(c => c.Approved)
                .CountAsync();

            // Utfør paginert spørring
            var chordsQuery = _context.SimpleChords
                .Where(c => c.Approved)
                .OrderBy(c => c.Song.Title) // Valgfritt: sorter etter tittel
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // Projiser resultatene til ChordsSearchListDto
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
