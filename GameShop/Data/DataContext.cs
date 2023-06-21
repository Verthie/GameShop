using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        */
    }
}
