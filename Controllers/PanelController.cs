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
        private IProjectRepository _repo;
        private IFileManager _fileManager;
        private ITechnologyTagRepository _repott;
        private IPTTRepository _repoptt;

        public PanelController(IProjectRepository repo, IFileManager fileManager, ITechnologyTagRepository repott, IPTTRepository repoptt)
        {
            _repo = repo;
            _fileManager = fileManager;
            _repott = repott;
            _repoptt = repoptt;
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
            var item = _repott.GetAllTechnologyTags();
            ProjectViewModel vm = new ProjectViewModel();
            vm.AvailableTechnologyTags = item;
            
            if (id == null)
            {
                ViewData["ButtonTitle"] = "Create new project";
                // return View(new ProjectViewModel());
                return View(vm);
            }
            else
            {
                ViewData["ButtonTitle"] = "Update the project";
                var project = _repo.GetProject((int) id);
                // return View(new ProjectViewModel
                // {
                //     Id = project.Id,
                //     Title = project.Title,
                //     Summary = project.Summary,
                //     Body = project.Body,
                //     CurrentImage = project.Image,
                //     IsCommercial = project.IsCommercial,
                //     IsWebProject = project.IsWebProject
                //  });              
                    vm.Id = project.Id;
                    vm.Title = project.Title;
                    vm.Summary = project.Summary;
                    vm.Body = project.Body;
                    vm.CurrentImage = project.Image;
                    vm.IsCommercial = project.IsCommercial;
                    vm.IsWebProject = project.IsWebProject;
                 return View (vm);
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

            if (project.Id > 0)
            {
                _repo.UpdateProject(project);
            }
            else
            {
                _repo.AddProject(project);
            }

            var aaa = new List<ProjectTechnologyTag>();
            foreach (var item in vm.AvailableTechnologyTags)
            {
                if (item.Selected == true)
                {
                    _repoptt.AddPTT(new ProjectTechnologyTag()
                    {
                        ProjectID = vm.Id,
                        TechnologyTagID = item.Id
                    });
                }
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