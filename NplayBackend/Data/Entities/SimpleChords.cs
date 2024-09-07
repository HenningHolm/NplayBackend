namespace NplayBackend.Data.Entities;


public class SimpleChords { 
    public Guid Id { get; set; }
    public List<string>? Intro { get; set; }
    public List<string>? Verse { get; set; }
    public List<string>? VerseEnd { get; set; }
    public List<string>? PreChorus { get; set; }
    public List<string>? Chorus { get; set; }
    public List<string>? ChorusEnd { get; set; }
    public List<string>? Bridge { get; set; }
    public List<string>? Outro { get; set; }
    public bool Approved { get; set; }
    public int Version { get; set; }
    public Guid SongId { get; set; }
    public Song Song { get; set; }
}
