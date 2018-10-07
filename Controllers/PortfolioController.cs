using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data;
using PortfolioWeb.Data.FileManager;
using PortfolioWeb.Data.Repository;
using PortfolioWeb.Models;

namespace PortfolioWeb.Controllers
{
    public class PortfolioController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public PortfolioController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
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

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}