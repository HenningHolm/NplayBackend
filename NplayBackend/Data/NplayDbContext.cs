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

}
