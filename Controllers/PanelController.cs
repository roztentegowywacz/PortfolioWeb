using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data.FileManager;
using PortfolioWeb.Data.Repository;
using PortfolioWeb.Models;
using PortfolioWeb.ViewModels;

namespace PortfolioWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IRepository repo, IFileManager fileManager)
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

        [HttpGet]
        public IActionResult Edit(int? id)
        { 
            if (id == null)
            {
                ViewData["ButtonTitle"] = "Create new project";
                return View(new PortfolioProjectViewModel());
            }
            else
            {
                ViewData["ButtonTitle"] = "Update the project";
                var portfolioProject = _repo.GetPortfolioProject((int) id);
                return View(new PortfolioProjectViewModel
                {
                    Id = portfolioProject.Id,
                    Title = portfolioProject.Title,
                    Summary = portfolioProject.Summary,
                    Body = portfolioProject.Body
                 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PortfolioProjectViewModel vm)
        {
            var portfolioProject = new PortfolioProject
            {
                Id = vm.Id,
                Title = vm.Title,
                Summary = vm.Summary,
                Body = vm.Body,
                Image = await _fileManager.SaveImage(vm.Image)
            };

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