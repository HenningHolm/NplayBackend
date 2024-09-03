using NPlay.Data.Enitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NplayBackend.Data.Entities;

namespace NplayBackend.Data;

public class NplayDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Song> Songs { get; set; }
    public DbSet<SimpleChords> SimpleChords { get; set; }

    public NplayDbContext(DbContextOptions<NplayDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var songAndChordsSeed = SeedBag.GetSongAndChordsSeed();

        modelBuilder.Entity<Song>(song =>
        {
            song.HasData(songAndChordsSeed.SongList);
        });

        modelBuilder.Entity<SimpleChords>(chords =>
        {
            chords.HasData(songAndChordsSeed.ChordsList);
        });
    }
}

