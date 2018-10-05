using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Models;

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

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new PortfolioProject());
        }

        [HttpPost]
        public IActionResult Edit(PortfolioProject portfolioProject)
        {
            return RedirectToAction("Index");
        }
    }
}