using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
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
                Firstname = client.Firstname,
                Lastname = client.Lastname,
                Email = client.Email,
                Address = client.Address,
                PostCode = client.PostCode,
                City = client.City,
                Country = client.Country,
                BirthDate = client.BirthDate,
                PhoneNumber = client.PhoneNumber,
                NativeCity = client.NativeCity,
                NativeCountry = client.NativeCountry,
                ProfessionnalStatusId = client.ProfessionnalStatusId,
                professionnalStatuses = professionnalStatusesList
            };

            return View(viewModel);
        }
    }
}
