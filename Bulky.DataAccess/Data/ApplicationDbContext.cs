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

        //creates table . DbSet represents table 
        public DbSet<Category> Categories{ get; set; }

        //overriding the default behavior: why ?
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId= Guid.NewGuid(),
                    DisplayOrder = 1,
                    Name = "Action"
                },
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    DisplayOrder = 2,
                    Name = "Sci-Fi"
                });
        }
    }
}
