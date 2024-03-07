using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MDT_Romania.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Raport> Raports { get; set; }
        public DbSet<Civilian> Civilians { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<BOLO> BOLOs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Crime> Crimes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet <Address> Addresses { get; set; }
        public DbSet<CrimeRaport> CrimeRaports { get; set; }


        protected override void OnModelCreating(ModelBuilder
modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // definire primary key compus
            modelBuilder.Entity<CrimeRaport>()
            .HasKey(cr => new {
                cr.RaportId,cr.CrimeId
            });
            // definire relatii cu modelele Crime si Raport (FK)
            modelBuilder.Entity<CrimeRaport>()
            .HasOne(ab => ab.Raport)
            .WithMany(ab => ab.CrimeRaports)
            .HasForeignKey(ab => ab.RaportId);
            modelBuilder.Entity<CrimeRaport>()
            .HasOne(ab => ab.Crime)
            .WithMany(ab => ab.CrimeRaports)
            .HasForeignKey(ab => ab.CrimeId);
        }

    }
}
