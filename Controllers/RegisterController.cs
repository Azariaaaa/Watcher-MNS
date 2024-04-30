using Microsoft.AspNetCore.Mvc;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Console.WriteLine("AllGoodBro");
            return RedirectToAction("Home");

        }
    }
}
