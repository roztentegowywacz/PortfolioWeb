using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data;
using PortfolioWeb.Data.FileManager;
using PortfolioWeb.Data.Repository;
using PortfolioWeb.Models;
using PortfolioWeb.ViewModels;

namespace PortfolioWeb.Controllers
{
    public class PortfolioController : Controller
    {
        private IProjectRepository _repo;
        private IFileManager _fileManager;

        public PortfolioController(IProjectRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var projects = _repo.GetAllProjects();
            foreach (var x in projects)
            {
                _repo.GetAssociatedTechnologyTags(x.Id);
            }
            return View(projects);
        }

        public IActionResult Project(int id)
        {
            var project = _repo.GetProject(id);
            _repo.GetAssociatedTechnologyTags(id);
            // if (project.ProjectTechnologyTags.Count == 0)
            return View(project);
        }

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}