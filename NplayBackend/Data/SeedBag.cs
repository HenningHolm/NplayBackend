using NplayBackend.Data.Entities;

namespace NplayBackend.Data;

    public static class SeedBag
    {
        public static Song[] GetSongs()
    {
            return
            [
                new Song { Id = new Guid(), Title = "All I Want", Artist = "Kodaline" },
                new Song { Id = new Guid(), Title = "High Hopes", Artist = "Kodaline" },
                new Song { Id = new Guid(), Title = "All By Myself", Artist = "Celine Dion"},    
            ];
        }
    }
