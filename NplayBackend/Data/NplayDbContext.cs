using Lojal.Data.Enitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NplayBackend.Data.Entities;

namespace NplayBackend.Data
{
    public class NplayDbContext : IdentityDbContext
    {
        //public DbSet<Song> Songs { get; set; }

        public NplayDbContext(DbContextOptions<NplayDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{ 
        //    modelBuilder.Entity<Song>(song =>
        //    {
        //        //song.Property(s => s.Id).IsRequired();
        //        //song.Property(s => s.Name).HasMaxLength(255).IsRequired();
        //        //song.Property(s => s.Artist).HasMaxLength(255).IsRequired();
        //        //song.Property(s => s.Published);

        //        var seedSongs = SeedBag.GetSongs();
        //        song.HasData(seedSongs);
        //    }); 
        //}

            //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
            //public DbSet<AuditLog> Audit { get; set; }


            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{

            //modelBuilder.Entity<ApplicationUser>(appUser =>
            //{
            //    //appUser.Property(a => a.VippsSub).IsRequired();
            //    appUser.Property(a => a.FirstName).HasMaxLength(255).IsRequired();
            //    appUser.Property(a => a.LastName).HasMaxLength(255).IsRequired();
            //    appUser.Property(a => a.FullName).HasMaxLength(255).IsRequired();
            //    appUser.Property(a => a.PhoneNumber).HasMaxLength(255).IsRequired();

            //    appUser.Property(a => a.CreatedBy).HasMaxLength(50).IsRequired();
            //    appUser.Property(a => a.CreatedDate).IsRequired();
            //});

            //modelBuilder.Entity<Agreement>(agreement =>
            //{

            //    agreement.Property(a => a.Status).HasConversion(s => s.ToString(),
            //        s => (AgreementStatus)Enum.Parse(typeof(AgreementStatus), s));
            //    //agreement.Property(a => a.Interval).HasConversion(s => s.ToString(),
            //    //    s => (Interval)Enum.Parse(typeof(Interval), s));
            //    //agreement.Property(a => a.Currency).HasConversion(s => s.ToString(),
            //    //s => (Currency)Enum.Parse(typeof(Currency), s));
            //});

            //}
        }
}
