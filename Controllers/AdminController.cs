using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            Client client = await _userManager.FindByIdAsync(viewModel.ClientId);
            IList<string> CurrentUserRole = await _userManager.GetRolesAsync(client);
            await _userManager.RemoveFromRolesAsync(client, CurrentUserRole);
            await _userManager.AddToRoleAsync(client, viewModel.NewRoleName);
            Console.WriteLine("viewModel.Client.Id" + viewModel.ClientId);
            Console.WriteLine("Current user role : " + CurrentUserRole[0]);
            Console.WriteLine("New role name : " + viewModel.NewRoleName);

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

    }
}
