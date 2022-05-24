using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //category
            mb.Entity<Category>().HasKey(c => c.CategoryId);

            mb.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(100);

            //Product
            mb.Entity<Product>().Property(c => c.Name).IsRequired().HasMaxLength(100);

            mb.Entity<Product>().Property(c => c.Description).IsRequired().HasMaxLength(255);

            mb.Entity<Product>().Property(c => c.ImageURL).IsRequired().HasMaxLength(255);

            mb.Entity<Product>().Property(c => c.Price).HasPrecision(12, 2);

            mb.Entity<Category>().HasMany(g => g.Products).WithOne(c => c.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar",
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessórios",
                }
            );
        }
    }
}
