
using NplayBackend.Data.Entities;
using NplayBackend.Models.Shared;
namespace NplayBackend.Data;

public class SeedSongAndChordResults
{
    public List<Song> SongList { get; set; }
    public List<SimpleChords> ChordsList { get; set; }
}

public static class SeedBag
{
    public static SeedSongAndChordResults GetSongAndChordsSeed()
    {

        // Perfect
        var songPerfect = new Song
        {
            Id = new Guid("93c46f97-0fd3-4d58-9875-72417acf0924"),
            Title = "Perfect",
            Artist = "Ed Sheeran",
            Chroma = 8,
            Scale = "G#",
            Difficulty = GeneralDifficulty.Medium,
            SpotifyCode = "spotify:track:0tgVpDi06FyKpA1z0VMD4v",
            YoutubeCode = "2Vv-BfVoq4g",
            Approved = true
        };
        var chordsPerfect = new SimpleChords
        {
            Id = new Guid("e9c2c7ab-3e93-4fb3-b0a7-36bfb6e70df1"),
            Verse = new List<string> { "0+", "9+m", "5+", "7+" },
            Chorus = new List<string> { "9+m", "5+", "0+", "7+" },
            SongId = songPerfect.Id,
            Approved = false
        };

        // Castle on the Hill
        var songCastleOnTheHill = new Song
        {
            Id = new Guid("591aead4-1d88-4366-bfac-5f67f3fc1695"),
            Title = "Castle on the Hill",
            Artist = "Ed Sheeran",
            Chroma = 2,
            Scale = "D",
            Difficulty = GeneralDifficulty.Medium,
            SpotifyCode = "spotify:track:6PCUP3dWmTjcTtXY02oFdT",
            YoutubeCode = "K0ibBPhiaG0",
            Approved = true
        };
        var chordsCastleOnTheHill = new SimpleChords
        {
            Id = new Guid("23a5d7e5-9c9d-4f3c-84b2-4f2e10a2e03a"),
            Verse = new List<string> { "0+", "5+", "9+m", "7+" },
            PreChorus = new List<string> { "5+", "7+", "0+", "5+", "7+", "0+", "5+", "7+" },
            Chorus = new List<string> { "0+", "5+", "9+m", "7+" },
            Bridge = new List<string> { "9+m", "5+", "0+", "7+" },
            SongId = songCastleOnTheHill.Id,
            Approved = false
        };

        // Shivers
        var songShivers = new Song
        {
            Id = new Guid("f4b3b3b4-1d88-4366-bfac-5f67f3fc1695"),
            Title = "Shivers",
            Artist = "Ed Sheeran",
            Chroma = 2,
            Scale = "D",
            Difficulty = GeneralDifficulty.Easy,
            SpotifyCode = "spotify:track:50nfwKoDiSYg8zOCREWAm5",
            YoutubeCode = "Il0S8BoucSA",
            Approved = true
        };
        var chordsShivers = new SimpleChords
        {
            Id = new Guid("a1f5c3d1-8b2a-4e2a-a7c8-83716c1d8cb8"),
            Verse = new List<string> { "9+m", "5+", "0+", "7+" },
            Chorus = new List<string> { "9+m", "5+", "0+", "7+" },
            SongId = songShivers.Id,
            Approved = false
        };

        // Overpass Graffiti
        var songOverpassGraffiti = new Song
        {
            Id = new Guid("b63b2c08-f150-4bb8-a702-7805194e64eb"),
            Title = "Overpass Graffiti",
            Artist = "Ed Sheeran",
            Chroma = 0,
            Scale = "C",
            Difficulty = GeneralDifficulty.Medium,
            SpotifyCode = "spotify:track:4btFHqumCO31GksfuBLLv3",
            YoutubeCode = "k6ZoE4RrcDs",
            Approved = false
        };
        var chordsOverpassGraffiti = new SimpleChords
        {
            Id = new Guid("95f6d2f4-9eb2-4e17-a5ea-d65c7ed1b6b2"),
            Verse = new List<string> { "9+m", "7+", "5+" },
            PreChorus = new List<string> { "7+", "5+", "7+", "5+", "7+" },
            Chorus = new List<string> { "0+", "7+", "2+m", "5+" },
            ChorusEnd = new List<string> { "7+" },
            SongId = songOverpassGraffiti.Id,
            Approved = false
        };

        // Thinking Out Loud
        var songThinkingOutLoud = new Song
        {
            Id = new Guid("747a77ac-4a1a-4a96-957b-6c37136b3fb2"),
            Title = "Thinking Out Loud",
            Artist = "Ed Sheeran",
            Chroma = 1,
            Scale = "D",
            Difficulty = GeneralDifficulty.Hard,
            SpotifyCode = "spotify:track:34gCuhDGsG4bRPIf9bb02f",
            YoutubeCode = "34gCuhDGsG4bRPIf9bb02f",
            Approved = true
        };
        var chordsThinkingOutLoud = new SimpleChords
        {
            Id = new Guid("d9e73f0a-89ba-4b8b-9d2c-3e537d2d7ea5"),
            Verse = new List<string> { "0+", "9+m7", "5+", "7+" },
            PreChorus = new List<string> { "2+m", "7+", "0+", "2+m", "7+", "2+m", "7+", "9+m", "2+m", "7+" },
            Chorus = new List<string> { "0+", "9+m7", "5+", "7+" },
            ChorusEnd = new List<string> { "9+m", "7+", "5+", "0+", "5+", "7+", "0+" },
            SongId = songThinkingOutLoud.Id,
            Approved = false
        };

        // Shape of You
        var songShapeOfYou = new Song
        {
            Id = new Guid("7c5ecbd8-5a76-4eb5-984c-a3bc90be5244"),
            Title = "Shape of You",
            Artist = "Ed Sheeran",
            Chroma = 2,
            Scale = "E",
            Difficulty = GeneralDifficulty.Medium,
            SpotifyCode = "spotify:track:7qiZfU4dY1lWllzX7mPBI3",
            YoutubeCode = null,
            Approved = true
        };

        // Photograph
        var songPhotograph = new Song
        {
            Id = new Guid("ce6e5559-4d14-442c-8490-c3e415d5420a"),
            Title = "Photograph",
            Artist = "Ed Sheeran",
            Chroma = 2,
            Scale = "F",
            Difficulty = GeneralDifficulty.Medium,
            SpotifyCode = "spotify:track:1HNkqx9Ahdgi1Ixy2xkKkL",
            YoutubeCode = null,
            Approved = true
        };

        // I don't care
        var songIDontCare = new Song
        {
            Id = new Guid("fedd2b44-d9ea-47e4-817c-cd924aacf935"),
            Title = "I don't care",
            Artist = "Ed Sheeran & Justin Bieber",
            Chroma = 2,
            Scale = "F#",
            Difficulty = GeneralDifficulty.Easy,
            SpotifyCode = "spotify:track:3HVWdVOQ0ZA45FuZGSfvns",
            YoutubeCode = "y83x7MgzWOA",
            Approved = true
        };
        var chordsIDontCare = new SimpleChords
        {
            Id = new Guid("3a69d00e-91f4-4a91-9298-6e5786a1f5e3"),
            Verse = new List<string> { "0+", "9+m", "5+", "7+" },
            Chorus = new List<string> { "0+", "9+m", "5+", "7+" },
            SongId = songIDontCare.Id,
            Approved = false
        };

        return new SeedSongAndChordResults
        {
            SongList = new List<Song>
            {
                songPerfect,
                songCastleOnTheHill,
                songShivers,
                songOverpassGraffiti,
                songThinkingOutLoud,
                songShapeOfYou,
                songPhotograph,
                songIDontCare
            },
            ChordsList = new List<SimpleChords>
            {
                chordsPerfect,
                chordsCastleOnTheHill,
                chordsShivers,
                chordsOverpassGraffiti,
                chordsThinkingOutLoud,
                chordsIDontCare
            }
        };
    }
}