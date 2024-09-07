namespace NplayBackend.Models.Dto;

public class SongWithSimpleChordsMiniDto
{
    public Guid SongId { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public List<string> ChromaArray { get; set; }
    public Guid SimpleChordsId { get; set; }
}

public class SongWithSimpleChordsDto
{
    public SongDto Song { get; set; }
    public SimpleChordsDto SimpleChords { get; set; }
}

public class SongWithNonApprovedSimpleChordsMiniDto
{
    public Guid SongId { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public Guid SimpleChordsId { get; set; }
}
