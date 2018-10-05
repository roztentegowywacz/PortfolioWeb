using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data;
using PortfolioWeb.Data.Repository;
using PortfolioWeb.Models;

namespace PortfolioWeb.Controllers
{
    public class PortfolioController : Controller
    {
        private IRepository _repo;

        public PortfolioController(IRepository repo)
        {
            _repo = repo;
        }

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
        public async Task<IActionResult> Edit(PortfolioProject portfolioProject)
        {
            _repo.AddPortfolioProject(portfolioProject);

            if (await _repo.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(portfolioProject);
            }

        }
    }
}