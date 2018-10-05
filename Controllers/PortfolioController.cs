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
            var portfolioProjects = _repo.GetAllPortfolioProjects();
            return View(portfolioProjects);
        }

        public IActionResult Project(int id)
        {
            var portfolioProject = _repo.GetPortfolioProject(id);
            return View(portfolioProject);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        { 
            if (id == null)
            {
                return View(new PortfolioProject());
            }
            else
            {
                var portfolioProject = _repo.GetPortfolioProject((int) id);
                return View(portfolioProject);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PortfolioProject portfolioProject)
        {
            if (portfolioProject.Id > 0)
            {
                _repo.UpdatePortfolioProject(portfolioProject);
            }
            else
            {
                _repo.AddPortfolioProject(portfolioProject);
            }

            if (await _repo.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(portfolioProject);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        { 
            _repo.RemovePortfolioProject(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}