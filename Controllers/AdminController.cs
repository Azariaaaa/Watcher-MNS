using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public AdminController(UserManager<Client> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> ManageRole(string id)
        {
            AdminEditRoleViewModel viewModel = new AdminEditRoleViewModel();

            Client? client = _dbContext.Client
                .Where(client => client.Id == id)
                .FirstOrDefault();

            viewModel.ClientId = id;
            viewModel.ClientLastname = client.Lastname;
            viewModel.ClientFirstname = client.Firstname;

            if (client != null)
            {
                var clientRole = await _userManager
                .GetRolesAsync(client);

                viewModel.Role = clientRole;
            }

            List<IdentityRole> existingRoles = _roleManager.Roles.ToList();

            viewModel.ExistingRoles = existingRoles;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRole(AdminEditRoleViewModel viewModel)
        {
            if(viewModel.ClientId != null)
            {
                Client client = await _userManager.FindByIdAsync(viewModel.ClientId);
                IList<string> CurrentUserRole = await _userManager.GetRolesAsync(client);
                await _userManager.RemoveFromRolesAsync(client, CurrentUserRole);
                await _userManager.AddToRoleAsync(client, viewModel.NewRoleName);
            }

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        public async Task<IActionResult> AdminEditUser(string id)
        {

            Client client = await _userManager.FindByIdAsync(id);

            List<ProfessionnalStatus> professionnalStatusesList = new List<ProfessionnalStatus>();
            professionnalStatusesList =  _dbContext.ProfessionnalStatus.ToList();

            AdminEditUserViewModel viewModel = new AdminEditUserViewModel
            {
                Id = id,
                UserToEdit = client,
                professionnalStatuses = professionnalStatusesList
            };

            Console.WriteLine("Fin premier Action");

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdminEditUser(string id, AdminEditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Client client = await _userManager.FindByIdAsync(id);

            client.Firstname = viewModel.UserToEdit.Firstname;
            client.Lastname = viewModel.UserToEdit.Lastname;
            client.Email = viewModel.UserToEdit.Email;
            client.Address = viewModel.UserToEdit.Address;
            client.PostCode = viewModel.UserToEdit.PostCode;
            client.City = viewModel.UserToEdit.City;
            client.Country = viewModel.UserToEdit.Country;
            client.BirthDate = viewModel.UserToEdit.BirthDate;
            client.PhoneNumber = viewModel.UserToEdit.PhoneNumber;
            client.NativeCity = viewModel.UserToEdit.NativeCity;
            client.NativeCountry = viewModel.UserToEdit.NativeCountry;
            client.ProfessionnalStatusId = viewModel.UserToEdit.ProfessionnalStatusId;

            await _userManager.UpdateAsync(client);
            
            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        public async Task<IActionResult> AdminAbsenceManager(string id)
        {
            Client? client = _dbContext.Client
                .FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Absence"))
                .Include(x => x.lateMissStatus)
                .ToList();

            var newLateMiss = new LateMiss();

            var viewModel = new AdminAbsenceDeclarationViewModel
            {
                User = client,
                ExistingLateMisses = existingLateMisses,
                NewLateMiss = newLateMiss
            };

            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> AdminAbsenceManager(AdminAbsenceDeclarationViewModel viewModel)
        {
            Client? client = _dbContext.Client
                .FirstOrDefault(x => x.Id == viewModel.User.Id);

            viewModel.NewLateMiss.Client = client;
            viewModel.NewLateMiss.DeclarationDate = DateTime.Now.Date;
            viewModel.NewLateMiss.LateMissType = "Absence";
            viewModel.NewLateMiss.StartDate = DateTime.Today.AddHours(8);
            viewModel.NewLateMiss.lateMissStatus = _dbContext.LateMissStatus
                .Where(lms => lms.Label == "Traité")
                .FirstOrDefault();


            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Absence"))
                .Include(x => x.lateMissStatus)
                .ToList();

            viewModel.ExistingLateMisses = existingLateMisses;

            _dbContext.LateMiss.Add(viewModel.NewLateMiss);
            _dbContext.SaveChanges();

            return RedirectToAction("AdminPanel", "AdminPanel");
        }


        public async Task<IActionResult> AdminDelayManager(string id)
        {
            Client? client = _dbContext.Client
               .FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Retard"))
                .Include(x => x.lateMissStatus)
                .ToList();

            var newLateMiss = new LateMiss();

            var viewModel = new AdminDelayDeclarationViewModel
            {
                User = client,
                ExistingLateMisses = existingLateMisses,
                NewLateMiss = newLateMiss
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdminDelayManager(AdminDelayDeclarationViewModel viewModel)
        {
            Client? client = _dbContext.Client
                .FirstOrDefault(x => x.Id == viewModel.User.Id);

            viewModel.NewLateMiss.Client = client;
            viewModel.NewLateMiss.DeclarationDate = DateTime.Now.Date;
            viewModel.NewLateMiss.LateMissType = "Retard";
            viewModel.NewLateMiss.StartDate = DateTime.Today.AddHours(8);
            viewModel.NewLateMiss.lateMissStatus = _dbContext.LateMissStatus
                .Where(lms => lms.Label == "Traité")
                .FirstOrDefault();


            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Retard"))
                .Include(x => x.lateMissStatus)
                .ToList();

            viewModel.ExistingLateMisses = existingLateMisses;

            _dbContext.LateMiss.Add(viewModel.NewLateMiss);
            _dbContext.SaveChanges();

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        public async Task<IActionResult> CreateProfessionnalStatus()
        {
            var existingProfessionnalStatuses = _dbContext.ProfessionnalStatus.ToList();
            CreateProfessionnalStatusViewModel viewModel = new CreateProfessionnalStatusViewModel();

            viewModel.existingProfessionnalStatuses = existingProfessionnalStatuses;
            

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessionnalStatus(CreateProfessionnalStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _dbContext.ProfessionnalStatus.Add(viewModel.ProfessionnalStatus);

            return RedirectToAction("AdminPanel", "AdminPanel");

        }


    }
}
