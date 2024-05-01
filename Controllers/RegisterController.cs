using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    public class RegisterController : Controller
    {
        private UserManager<Client> _userManager { get; set; }

        public RegisterController(UserManager<Client> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Account/Register.cshtml", viewModel);
            }

            Client client = new Client
            {
                Firstname = viewModel.Firstname,
                Lastname = viewModel.Lastname,
                Email = viewModel.Email,
                UserName = viewModel.Email
            };

            var result = await _userManager.CreateAsync(client, viewModel.Password);
            if (result.Succeeded )
            {
                Console.WriteLine("All Good doog.");
                return RedirectToAction("Home");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                    ModelState.AddModelError("Register", error.Description);
                    return View(viewModel);
                }
            }

            return RedirectToAction("Home");
        }
    }
}
