using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.ViewModels;

namespace PortfolioWeb.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result =  await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
            
            return RedirectToAction("Index", "Panel");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}