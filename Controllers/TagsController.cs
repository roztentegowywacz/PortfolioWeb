using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data;
using PortfolioWeb.Data.Repository;
using PortfolioWeb.Models;
using PortfolioWeb.ViewModels;

namespace PortfolioWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagsController : Controller
    {
        private IRepository _repo;
        private ITechnologyTagRepository _technologyTagRepo;
        private IProjectRepository _repoPP;
        private AppDbContext _context;

        public TagsController(IRepository repo, ITechnologyTagRepository technologyTagRepo, IProjectRepository repoPP, AppDbContext context)
        {
            _repo = repo;
            _technologyTagRepo = technologyTagRepo;
            _repoPP = repoPP;
            _context = context;
        }

        public IActionResult Index()
        {
            var technologyTags = _technologyTagRepo.GetAllTechnologyTags();
            return View(technologyTags);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        { 
            if (id == null)
            {
                ViewData["Title"] = "Create new Technology Tag";
                ViewData["ButtonTitle"] = "Create";
                return View(new TechnologyTagViewModel());
            }
            else
            {
                ViewData["Title"] = "Update the Technology Tag";
                ViewData["ButtonTitle"] = "Update";
                var technologyTag = _technologyTagRepo.GetTechnologyTag((int) id);
                return View(new TechnologyTagViewModel
                {
                    Id = technologyTag.Id,
                    Name = technologyTag.Name,
                    CssClassName = technologyTag.CssClassName
                 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TechnologyTagViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var technologyTag = new TechnologyTag
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    CssClassName = vm.CssClassName
                };

                if (technologyTag.Id > 0)
                {
                    _technologyTagRepo.UpdateTechnologyTag(technologyTag);
                }
                else
                {
                    _technologyTagRepo.AddTechnologyTag(technologyTag);
                }

                if (await _repo.SaveChangesAsync())
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(technologyTag);
                }
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        { 
            _technologyTagRepo.RemoveTechnologyTag(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult ViewTag(int id)
        {
            var associatedProjects = _technologyTagRepo.GetAssociatedProjects(id);
            var technologyTag = _technologyTagRepo.GetTechnologyTag(id);
            return View(new ViewTagViewModel
            {
                AssociatedProjects = associatedProjects,
                TechnologyTag = technologyTag
            });
        }
    }
}