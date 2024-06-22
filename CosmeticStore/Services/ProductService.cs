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
    }
}
