namespace NplayBackend.Data.Entities;

public enum GeneralDifficulty
{   
    Easy,
    Medium,
    Hard
}

public enum Recognition
{
    International,
    Latino,
    Scandinavian,
}

public class Song
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Chroma { get; set; }
    public string Scale { get; set; }
    public int? BPM { get; set; }
    public GeneralDifficulty Difficulty { get; set; }
    public List<Recognition>? Recognitions { get; set; }
    
    public string? SpotifyCode { get; set; }
    public string? YoutubeCode { get; set; }
    public bool Approved { get; set; }
}