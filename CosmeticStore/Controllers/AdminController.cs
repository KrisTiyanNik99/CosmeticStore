using BeautyCareStore.Models;
using BeautyCareStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCareStore.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public AdminController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AdminPanel()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);
                return View("AdminPanel", await _productService.GetAllProductsAsync());
            }
            ModelState.AddModelError(string.Empty, ModelState.ToString());
            return View("AdminPanel");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("AdminPanel");
        }
    }
}
