using NplayBackend.Models.Shared;

namespace NplayBackend.Models.Dto;

public class SongMinimalDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
}

public class SongDto
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
}


