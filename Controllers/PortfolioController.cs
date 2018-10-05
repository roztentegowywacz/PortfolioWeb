using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Project()
        {
            return View();
        }
    }
}