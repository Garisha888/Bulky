
using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //seeding data to database
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }


                );
            //modelBuilder.Entity<Category>()
            //    .HasKey(c => c.Id);
            //var categoryList = new List<Category>
            //{
            //     new Category { Id =1, Name= "Action", DisplayOrder=1},
            //    new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            //    new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            //};
            //modelBuilder.Entity<Category>().HasData(categoryList);
            //Category cg = new Category();
            //cg.Id = 4;  
            //cg.Name = "abc";
            //cg.DisplayOrder = 4;
            //modelBuilder.Entity<Category>().HasData(cg);

            //base.OnModelCreating(modelBuilder);

        }

    }
}
