using Microsoft.EntityFrameworkCore;

namespace CosmeticStore.Models
{
    public class BeautyCareDbContext : DbContext
    {
        public BeautyCareDbContext(DbContextOptions<BeautyCareDbContext> options)
    : base(options)
        {
        }
        
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Configure Products entity
            modelBuilder.Entity<Products>()
                .Property(p => p.Name)
                .IsRequired();

            // Example: Seed initial data
            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Product 1", Price = 10.00m },
                new Products { Id = 2, Name = "Product 2", Price = 15.00m }
            );
        }
    }
}