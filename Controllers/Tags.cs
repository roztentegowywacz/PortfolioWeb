using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data.Repository;
using PortfolioWeb.Models;
using PortfolioWeb.ViewModels;

namespace PortfolioWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Tags : Controller
    {
        private ITechnologyTagRepository _repo;

        public Tags(ITechnologyTagRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var technologyTags = _repo.GetAllTechnologyTags();
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
                var technologyTag = _repo.GetTechnologyTag((int) id);
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
                    _repo.UpdateTechnologyTag(technologyTag);
                }
                else
                {
                    _repo.AddTechnologyTag(technologyTag);
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
            _repo.RemoveTechnologyTag(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}