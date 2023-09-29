using Chess.Domain.Models.People;
using Microsoft.EntityFrameworkCore;


namespace Chess.Persistance.Emplamentation
{
    internal sealed class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = main.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
