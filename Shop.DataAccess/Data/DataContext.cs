using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Platforming", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Souls-like", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Rouge-lite", DisplayOrder = 4 },
                new Category { Id = 5, Name = "RPG", DisplayOrder = 5 },
                new Category { Id = 6, Name = "MMO", DisplayOrder = 6 }
                );
        }
    }
}
