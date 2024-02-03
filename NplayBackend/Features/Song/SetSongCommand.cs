using NplayBackend.Data;
namespace NplayBackend.Features.Song;

public class SetSongCommand
{
    private readonly ILogger<SetSongCommand> _logger;
    private readonly NplayDbContext _context;

    public SetSongCommand(ILogger<SetSongCommand> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task ExecuteAsync(string message)
    {
        try
        {
            //var prevNote = await _context.Notes.FirstOrDefaultAsync(n => !n.IsDeleted);
            //if (prevNote != null)
            //{
            //    prevNote.IsDeleted = true;
            //}

            //var note = new Database.Note()
            //{
            //    Message = message,
            //    TimeCreated = TimeOnly.FromDateTime(DateTime.UtcNow),
            //    DateCreated = DateOnly.FromDateTime(DateTime.UtcNow)
            //};

            //_context.Add(note);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception occured during SetOverviewNoteOperation");
            throw;
        }
    }
}



