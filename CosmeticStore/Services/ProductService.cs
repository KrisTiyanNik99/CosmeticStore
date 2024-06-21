using CosmeticStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticStore.Services
{
    public class ProductService
    {
        private readonly BeautyCareDbContext _context;

        public ProductService(BeautyCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
