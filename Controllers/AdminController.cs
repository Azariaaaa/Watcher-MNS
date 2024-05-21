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

            viewModel.Client = client;

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

        //[HttpPost]
        //public IActionResult ManageRole(AdminEditRoleViewModel viewModel)
        //{
        //    _userManager.role
        //}

    }
}
