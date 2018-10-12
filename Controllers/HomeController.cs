using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data;
using PortfolioWeb.Data.Repository;

namespace PortfolioWeb.Controllers
{
    public class HomeController : Controller
    {
        private ITechnologyTagRepository _repo;

        public HomeController(ITechnologyTagRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var technologyTags = _repo.GetAllTechnologyTags();
            return View(technologyTags);
        }
    }
}