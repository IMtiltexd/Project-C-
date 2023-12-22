using ESHOP.Models;
using ESHOP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESHOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sterm = "", int categoryId = 0, int manufacturerId = 0)
        {
            IEnumerable<Item> items = await _homeRepository.GetProducts(sterm, categoryId, manufacturerId);
            IEnumerable<Category> categories = await _homeRepository.Categories();
            IEnumerable<Manufacturer> manufacturers = await _homeRepository.Manufacturers();

            ProductDisplayModel productModel = new ProductDisplayModel
            {
                Items = items,
                Categories = categories,
                Manufacturers = manufacturers,
                STerm = sterm,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId
            };

            return View(productModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}