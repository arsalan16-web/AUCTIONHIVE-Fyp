using System.Diagnostics;
using AUCTIONHIVE.Data;
using AUCTIONHIVE.Models;
using Microsoft.AspNetCore.Mvc;

namespace AUCTIONHIVE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public  async Task< IActionResult> Index()
        {
            ProductsViewModel model = new ProductsViewModel();

            var allProduct =  _context.Products.Where(x=>x.Status=="Active");



            return View(model);
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
