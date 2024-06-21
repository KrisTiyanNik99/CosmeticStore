using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CosmeticStore.Models
{
    public class BeautyCareDbContext : IdentityDbContext<CustomUser>
    {
        public BeautyCareDbContext(DbContextOptions<BeautyCareDbContext> options)
    : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Configure Products entity
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

            // Example: Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Price = 10.00m },
                new Product { Id = 2, Name = "Product 2", Price = 15.00m }
            );
        }
    }
}