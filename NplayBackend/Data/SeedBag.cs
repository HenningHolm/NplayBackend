using NplayBackend.Data.Entities;

namespace NplayBackend.Data;

    public static class SeedBag
    {
        public static Song[] GetSongs()
    {
            return
            [
                new Song { Id = new Guid(), Name = "All I Want", Artist = "Kodaline", Published = 2013 },
                new Song { Id = new Guid(), Name = "High Hopes", Artist = "Kodaline", Published = 2013 },
                new Song { Id = new Guid(), Name = "All By Myself", Artist = "Celine Dion", Published = 1996 },    
            ];
        }
    }
