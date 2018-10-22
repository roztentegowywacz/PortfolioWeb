using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Tutaj wyswietlam listę wszystkich wpisów na blogu

            return View();
        }

        public IActionResult Post(int id)
        {
            // TODO: Tutaj będzie wyświetlany jeden post
            // - na koncu odniesienie do kolejnego posta
            // - na koncu posta komentarze

            return View();
        }
    }
}