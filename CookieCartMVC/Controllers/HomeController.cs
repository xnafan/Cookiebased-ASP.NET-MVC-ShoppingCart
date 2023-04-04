using CookieCartMVC.DataAccessLayer;
using CookieCartMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookieCartMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductDao _productDao;

        public HomeController(IProductDao productDao) => _productDao = productDao;

        public IActionResult Index() => View(_productDao.GetAllProducts());


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}