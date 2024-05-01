using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    public class LoginController : Controller
    {
        private SignInManager<Client> _signInManager { get; set; }

        public LoginController(SignInManager<Client> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                View("~/Views/Account/Login.cshtml", viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(
                viewModel.Email,
                viewModel.Password,
                true,
                false
                );

            if (result.Succeeded)
            {
                return RedirectToAction("Home");
            }
            else
            {
                if(result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "Votre compte est bloqué");
                }
                else
                {
                    ModelState.AddModelError("Login", "Mot de passe ou Email incorrect");
                }
            }
            return View("~/Views/Account/Login.cshtml", viewModel);
        }
    }
}
