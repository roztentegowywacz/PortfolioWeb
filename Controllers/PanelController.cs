using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data.Repository;
using PortfolioWeb.Models;

namespace PortfolioWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;

        public PanelController(IRepository repo)
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