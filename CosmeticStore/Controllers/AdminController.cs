    using BeautyCareStore.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    namespace BeautyCareStore.Controllers
    {
        public class AdminController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly ProductService _productService;

            public AdminController(ILogger<HomeController> logger, ProductService productService)
            {
                _logger = logger;
                _productService = productService;
            }

            [Authorize(Roles = "Admin")]
            public IActionResult Index()
            {
                return View();
            }

            public async Task<IActionResult> AdminPanel()
            {
                var products = await _productService.GetAllProductsAsync();
                return View();
            }
        }
    }
