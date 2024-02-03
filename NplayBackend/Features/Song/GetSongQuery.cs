using NplayBackend.Data;

namespace NplayBackend.Features.Song;

  public class GetSongQuery
{
    private readonly ILogger<GetSongQuery> _logger;
    private readonly NplayDbContext _context;

    public GetOverviewNoteQuery(ILogger<GetSongQuery> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<NoteDto> ExecuteAsync()
    {
        try
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => !n.IsDeleted);

            if (note == null)
            {
                return null;
            }
            return new NoteDto { Message = note.Message };
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occured during GetOverviewNoteQuery");
            throw;
        }
    }

}