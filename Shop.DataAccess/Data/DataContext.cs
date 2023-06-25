using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.DataAccess.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Platforming", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Souls-like", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Rouge-lite", DisplayOrder = 4 },
                new Category { Id = 5, Name = "RPG", DisplayOrder = 5 },
                new Category { Id = 6, Name = "MMO", DisplayOrder = 6 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                { Id = 1, Title = "Bright Souls", Description = "Prepare to live", Developer = "Form Hardware", Publisher = "Nandai Bamco", Price = 59.99, Price50 = 49.99, Price100 = 39.99, CategoryId = 3, ImageURL = "" },
                new Product { Id = 2, Title = "Bright Souls 2", Description = "Prepare to live again", Developer = "Form Hardware", Publisher = "Nandai Bamco", Price = 59.99, Price50 = 49.99, Price100 = 39.99, CategoryId = 3, ImageURL = "" },
                new Product { Id = 3, Title = "Dean Simulator", Description = "Prepere to die", Developer = "Form Hardware, Bimtendo, Circle Enix, Bugisoft, Icestorm, DVD Projekt BLUE, Altus", Publisher = "NASA", Price = 69.99, Price50 = 59.99, Price100 = 49.99, CategoryId = 7, ImageURL = "" },
                new Product { Id = 4, Title = "Dean Simulator - Revenge", Description = "The sequel to the critically acclaimed masterpiece Dean Simulator", Developer = "Form Hardware, Bimtendo, Circle Enix, Bugisoft, Icestorm, DVD Projekt BLUE, Altus", Publisher = "NASA", Price = 69.99, Price50 = 59.99, Price100 = 49.99, CategoryId = 7, ImageURL = "" },
                new Product { Id = 5, Title = "Student Simulator 2023", Description = "Hardest game ever - IGN", Developer = "Dean", Publisher = "Dean", Price = 59.99, Price50 = 49.99, Price100 = 39.99, CategoryId = 7, ImageURL = "" },
                new Product { Id = 6, Title = "Super Maria Sisters", Description = "One of the most well known games in the whole universe", Developer = "Bimtendo", Publisher = "Bimtendo", Price = 59.99, Price50 = 49.99, Price100 = 39.99, CategoryId = 2, ImageURL = "" },
                new Product { Id = 7, Title = "Super Maria Sisters 2", Description = "Game of the Year, every year", Developer = "Bimtendo", Publisher = "Bimtendo", Price = 59.99, Price50 = 49.99, Price100 = 39.99, CategoryId = 2, ImageURL = "" }
                );
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Z-Kom", StreetAddress = "Krakowska 3", City = "Rzeszów", Region = "Podkarpackie", PostalCode = "35-021", PhoneNumber = "543462385"},
                new Company { Id = 2, Name = "Morela.pl", StreetAddress = "Metrowa 43", City = "Warszawa", Region = "Mazowieckie", PostalCode = "00-001", PhoneNumber = "684439642"},
                new Company { Id = 3, Name = "Media Master", StreetAddress = "Poznańska 7", City = "Rzeszów", Region = "Podkarpackie", PostalCode = "35-021", PhoneNumber = "683124754"}
    );
        }
    }
}
