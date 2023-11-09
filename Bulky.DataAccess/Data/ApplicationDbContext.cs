using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Data
{
    //ApplicationDbContext inherits DbContext class
    public class ApplicationDbContext : DbContext
    {
        //whatever configuration we do for ApplicationDbContext class, will be passed to DbContext class 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //creates table . DbSet represents table . 
        //if not written, exception on empty table
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }


        //overriding the default behavior
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid(); 
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = guid1,
                    DisplayOrder = 1,
                    Name = "Action"
                },
                new Category
                {
                    CategoryId = guid2,
                    DisplayOrder = 2,
                    Name = "Sci-Fi"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Author = "Rabindranath Tagore",
                    Description = "Early 20th century Indian Literature",
                    Price = 20,
                    Price100 = 13,
                    Price50 = 17,
                    Title = "Chokher Bali",
                    ISBN = "0123456789",
                    CategoryId= guid1,
                    ImageUrl = ""
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Author = "Neil Gaiman",
                    Description = "American Gods",
                    Price = 20,
                    Price100 = 13,
                    Price50 = 17,
                    Title = "American Gods",
                    ISBN = "7894631",
                    CategoryId = guid2,
                    ImageUrl = ""
                });
        }
    }
}
