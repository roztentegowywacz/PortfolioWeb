using System.Collections.Generic;
using System.Linq;
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
        private IProjectRepository _projectRepo;
        private IFileManager _fileManager;
        private ITechnologyTagRepository _repott;
        private IPTTRepository _repoptt;

        public PanelController(IRepository repo, IProjectRepository projectRepo, IFileManager fileManager, ITechnologyTagRepository repott, IPTTRepository repoptt)
        {
            _repo = repo;
            _projectRepo = projectRepo;
            _fileManager = fileManager;
            _repott = repott;
            _repoptt = repoptt;
        }

        public IActionResult Index()
        {
            var projects = _projectRepo.GetAllProjects();
            return View(projects);
        }

        public IActionResult Project(int id)
        {
            var project = _projectRepo.GetProject(id);
            return View(project);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // ProjectViewModel vm = new ProjectViewModel();
            // vm.AvailableTechnologyTags = _repott.GetAllTechnologyTags();
            
            if (id == null)
            {
                ViewData["ButtonTitle"] = "Create new project";
                // return View(new ProjectViewModel());
                // return View(vm);
                return View(new ProjectViewModel
                {
                    AvailableTechnologyTags = _repott.GetAllTechnologyTags()
                });
            }
            else
            {
                ViewData["ButtonTitle"] = "Update the project";
                var project = _projectRepo.GetProject((int) id);
                var selectedTechnologyTags = _projectRepo.GetAssociatedTechnologyTags((int) id);
                var availableTechnologyTags = _repott.GetAllTechnologyTags();

                foreach (var tag in selectedTechnologyTags)
                {
                    var change = availableTechnologyTags.Single(x => x.Id == tag.TechnologyTagID);
                    change.Selected = true;
                }
                return View(new ProjectViewModel
                {
                    Id = project.Id,
                    Title = project.Title,
                    Summary = project.Summary,
                    Body = project.Body,
                    CurrentImage = project.Image,
                    IsCommercial = project.IsCommercial,
                    IsWebProject = project.IsWebProject,
                    AvailableTechnologyTags = availableTechnologyTags
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
                if (!string.IsNullOrEmpty(vm.CurrentImage))
                {
                    _fileManager.RemoveImage(vm.CurrentImage);
                }
                project.Image = await _fileManager.SaveImage(vm.Image);
            }
            
            var aaa = _repoptt.GetAllPTT();
            foreach (var tag in vm.AvailableTechnologyTags)
            {
                var bbb = new ProjectTechnologyTag
                {
                    ProjectID = vm.Id, 
                    TechnologyTagID = tag.Id
                };
                if (aaa.Any(x => x.ProjectID == bbb.ProjectID && x.TechnologyTagID == bbb.TechnologyTagID) && tag.Selected == false)
                {
                    _repoptt.RemovePTT(bbb.ProjectID, bbb.TechnologyTagID);
                    await _repo.SaveChangesAsync();
                }
                else if (!aaa.Any(x => x.ProjectID == bbb.ProjectID && x.TechnologyTagID == bbb.TechnologyTagID) && tag.Selected == true)
                {
                    _repoptt.AddPTT(bbb);
                    await _repo.SaveChangesAsync();
                }
            }

            if (project.Id > 0)
            {
                _projectRepo.UpdateProject(project);
            }
            else
            {
                _projectRepo.AddProject(project);
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
            _projectRepo.RemoveProject(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        } 
    }
}