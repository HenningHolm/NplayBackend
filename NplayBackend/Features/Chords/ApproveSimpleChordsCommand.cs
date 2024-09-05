using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.Data.Entities;

namespace NplayBackend.Features.Chords;

public interface IApproveSimpleChordsCommand
{
    Task<List<string>> ExecuteAsync(Guid chordsId);
}

public class ApproveSimpleChordsCommand : IApproveSimpleChordsCommand
{
    private readonly ILogger<ApproveSimpleChordsCommand> _logger;
    private readonly NplayDbContext _context;

    public ApproveSimpleChordsCommand(ILogger<ApproveSimpleChordsCommand> logger, NplayDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<List<string>> ExecuteAsync(Guid simpleChordsId)
    {
        // Fetch the SimpleChords object from the database
        var simpleChords = await _context.SimpleChords
            .Include(sc => sc.Song) // Include the related Song
            .FirstOrDefaultAsync(sc => sc.Id == simpleChordsId);

        if (simpleChords == null)
        {
            throw new Exception("SimpleChords not found");
        }

        // Generate the sorted list of chords from SimpleChords
        var sortedChords = GenerateSortedChordList(simpleChords);

        // Update the Song's ChromaArray with the sorted list
        simpleChords.Song.ChromaArray = sortedChords;

        // Mark the chords as approved
        simpleChords.Approved = true;

        // Save changes to the database
        await _context.SaveChangesAsync();

        // Return the sorted list of unique chords
        return sortedChords;
    }

    // Method to extract and format the chords in the correct order
    private List<string> GenerateSortedChordList(SimpleChords simpleChords)
    {
        // Combine all the chords from the different sections
        var allChords = new List<string>();
        allChords.AddRange(simpleChords.Intro ?? new List<string>());
        allChords.AddRange(simpleChords.Verse ?? new List<string>());
        allChords.AddRange(simpleChords.VerseEnd ?? new List<string>());
        allChords.AddRange(simpleChords.PreChorus ?? new List<string>());
        allChords.AddRange(simpleChords.Chorus ?? new List<string>());
        allChords.AddRange(simpleChords.ChorusEnd ?? new List<string>());
        allChords.AddRange(simpleChords.Bridge ?? new List<string>());
        allChords.AddRange(simpleChords.Outro ?? new List<string>());

        // Remove duplicates using a HashSet
        var seenChords = new HashSet<string>();
        var uniqueChordsInOrder = allChords.Where(chord => seenChords.Add(chord)).ToList();

        // Sort the chords in ascending order based on the numeric part of the chord
        var sortedChords = uniqueChordsInOrder
            .OrderBy(chord => ExtractNumericValue(chord)) // Sort based on the numeric value in the chord
            .ToList();

        return sortedChords;
    }

    // Helper method to extract the numeric value from a chord
    private int ExtractNumericValue(string chord)
    {
        // Extract only the numeric part from the chord (the first part which is a number)
        var baseChord = new string(chord.TakeWhile(char.IsDigit).ToArray());
        return int.Parse(baseChord);
    }
}

