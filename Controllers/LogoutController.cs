using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchMNS.Models;

namespace WatchMNS.Controllers
{
    public class LogoutController : Controller
    {
        private SignInManager<Client> _signInManager { get; set; }

        public LogoutController(SignInManager<Client> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); //Action , Controller
        }
    }
}
