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
        private IProjectRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IProjectRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var projects = _repo.GetAllProjects();
            return View(projects);
        }

        public IActionResult Project(int id)
        {
            var project = _repo.GetProject(id);
            return View(project);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        { 
            if (id == null)
            {
                ViewData["ButtonTitle"] = "Create new project";
                return View(new ProjectViewModel());
            }
            else
            {
                ViewData["ButtonTitle"] = "Update the project";
                var project = _repo.GetProject((int) id);
                return View(new ProjectViewModel
                {
                    Id = project.Id,
                    Title = project.Title,
                    Summary = project.Summary,
                    Body = project.Body,
                    CurrentImage = project.Image,
                    IsCommercial = project.IsCommercial,
                    IsWebProject = project.IsWebProject
                 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectViewModel vm)
        {
            var project = new Project
            {
                Id = vm.Id,
                Title = vm.Title,
                Summary = vm.Summary,
                Body = vm.Body,
                IsCommercial = vm.IsCommercial,
                IsWebProject = vm.IsWebProject
            };

            if (vm.Image == null)
            {
                project.Image = vm.CurrentImage;
            }
            else
            {
                project.Image = await _fileManager.SaveImage(vm.Image);
            }

            if (project.Id > 0)
            {
                _repo.UpdateProject(project);
            }
            else
            {
                _repo.AddProject(project);
            }

            if (await _repo.SaveChangesAsync())
            {
                return Redirect($"/Portfolio/Project/{project.Id}");
                // return RedirectToAction("Index");
            }
            else
            {
                return View(project);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        { 
            _repo.RemoveProject(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        } 
    }
}