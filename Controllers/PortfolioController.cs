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
    }
}