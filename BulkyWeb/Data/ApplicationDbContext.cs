using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    //ApplicationDbContext inherits DbContext class
    public class ApplicationDbContext : DbContext
    {
        //whatever configuration we do for ApplicationDbContext class, will be passed to DbContext class 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //creates table . DbSet represents table 
        public DbSet<Category> Categories{ get; set; }

        //overriding the default behavior: why ?
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId= 1,
                    DisplayOrder = 1,
                    Name = "Action"
                },
                new Category
                {
                    CategoryId = 2,
                    DisplayOrder = 2,
                    Name = "Sci-Fi"
                });
        }
    }
}
