using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.Controllers
{
    public class BlogPanelController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Tutaj wyswietlam listę wszystkich wpisów na blogu

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // TODO: tutaj panel do edycji i tworzenia posta
            return View();
        }

        [HttpPost]
        public IActionResult Edit()
        {
            // TODO: przetworzyc rzadanie i zapisać albo zaktualizowac post w bazie

            return View();
        }

        public IActionResult Remove(int id)
        {
            // TODO: Kontroler do usuwania posta
            
            return RedirectToAction("Edit");
        }
    }
}