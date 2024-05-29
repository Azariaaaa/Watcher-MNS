using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            string id = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            Client? client = _dbContext.Client
                .Where(x => x.Id == id)
                .FirstOrDefault();

            List<ProfessionnalStatus> professionnalStatusesList = _dbContext.ProfessionnalStatus
                .ToList();


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
            viewModel.ProfessionnalStatusId = client.ProfessionnalStatusId;
            viewModel.professionnalStatuses = professionnalStatusesList;

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

            Client? client = _dbContext.Client
                .Where(x => x.Id == viewModel.Id)
                .FirstOrDefault();

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
            client.ProfessionnalStatusId = viewModel.ProfessionnalStatusId;

            _dbContext.Client.Update(client);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DisplayUser()
        {
            string? id = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            Client? client = _dbContext.Client
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var clientRoles = await _userManager
                .GetRolesAsync(client);

            var clientProStatus = _dbContext.ProfessionnalStatus
                .Where(x => x.Id == client.ProfessionnalStatusId)
                .FirstOrDefault();

            int totalAbsence = _dbContext.LateMiss
                .Where(lm => lm.LateMissType == "Absence" && lm.Client.Id == client.Id)
                .ToList()
                .Count();

            int totalDelay = _dbContext.LateMiss
                .Where(lm => lm.LateMissType == "Retard" && lm.Client.Id == client.Id)
                .ToList()
                .Count();

            float absencePercentage = (float) (totalAbsence * 100) / 218;
            float delayPercentage = (float) (totalDelay * 100) / 218;

            DisplayUserViewModel viewModel = new DisplayUserViewModel();

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
            viewModel.Role = clientRoles;
            viewModel.TotalAbsence = totalAbsence;
            viewModel.TotalDelay = totalDelay;
            viewModel.AbsencePercentage = (float) Math.Round(absencePercentage, 2);
            viewModel.DelayPercentage = (float) Math.Round(delayPercentage, 2);

            if (clientProStatus != null)
                viewModel.ProfessionnalStatusLabel = clientProStatus.Label;
            else
                viewModel.ProfessionnalStatusLabel = "Aucun";

            return View(viewModel);
        }
    }
}
