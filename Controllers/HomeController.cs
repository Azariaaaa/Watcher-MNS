using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WatchMNS.Models;

namespace WatchMNS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<Client> _userManager { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<Client> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Panel", "AdminPanel");

            if (User.IsInRole("User"))
                return RedirectToAction("Panel", "UserPanel");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult UserIndex()
        {
            return View();
        }
    }
}
