using BeautyCareStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyCareStore.Services
{
    public class ProductService
    {
        private readonly BeautyCareDbContext _context;

        public ProductService(BeautyCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products != null)
            {
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
            }
        }
    }
}
