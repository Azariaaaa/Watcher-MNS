using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    public class ManageAccountController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }

        public ManageAccountController(UserManager<Client> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult EditUser()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client? client = _dbContext.Client.Where(x => x.Id == id).FirstOrDefault();

            UserEditUserViewModel viewModel = new UserEditUserViewModel();
            viewModel.Id = id;
            viewModel.Lastname = client.Lastname;
            viewModel.Firstname = client.Firstname;
            viewModel.Email = client.Email;
            viewModel.Address = client.Address;
            viewModel.City = client.City;
            viewModel.PostCode = client.PostCode;
            viewModel.Country = client.Country;
            viewModel.PhoneNumber = client.PhoneNumber;
            viewModel.NativeCity = client.NativeCity;
            viewModel.NativeCountry = client.NativeCountry;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserEditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                foreach (string key in ModelState.Keys)
                {
                    ModelError? error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(viewModel);
            }

            Client? client = _dbContext.Client.Where(x => x.Id == viewModel.Id).FirstOrDefault();

            client.Lastname = viewModel.Lastname;
            client.Firstname = viewModel.Firstname;
            client.Email = viewModel.Email;
            client.Address = viewModel.Address;
            client.City = viewModel.City;
            client.PostCode = viewModel.PostCode;
            client.Country = viewModel.Country;
            client.BirthDate = viewModel.BirthDate;
            client.PhoneNumber = viewModel.PhoneNumber;
            client.NativeCity = viewModel.NativeCity;
            client.NativeCountry = viewModel.NativeCountry;

            _dbContext.Client.Update(client);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
