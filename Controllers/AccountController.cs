using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<Client> _signInManager { get; set; }
        private UserManager<Client> _userManager { get; set; }

        public AccountController(SignInManager<Client> signInManager, UserManager<Client> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //LOGIN
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Account/Login.cshtml");
        }

        //LOGIN POST
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (result.IsLockedOut)
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

        //LOGOUT
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); //Action , Controller
        }

        //REGISTER
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        //REGISTER POST
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

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(client, "User");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                    ModelState.AddModelError("Register", error.Description);
                    return View(viewModel);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
