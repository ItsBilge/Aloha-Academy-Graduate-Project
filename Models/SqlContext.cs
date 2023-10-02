using Microsoft.EntityFrameworkCore;

namespace Aloha_Academy_Graduate_Project.Models
{
    public class SqlContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= LAPTOP-3AOA7VRF\\SQLEXPRESS; database = ActivityDb ; trusted_connection = true; TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
           .HasOne(a => a.Category)
           .WithMany(c => c.Activities)
           .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Activity>()
            .HasOne(a => a.Location)
            .WithMany(l => l.Activities)
            .HasForeignKey(a => a.LocationId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
