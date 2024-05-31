using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public UserController(UserManager<Client> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public ActionResult DocumentManager()
        {
            string? CurrentUserId = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            Client? CurrentUser = _dbContext.Client.Where(u  => u.Id == CurrentUserId).FirstOrDefault();

            UserDocumentManagerViewModel viewModel = new UserDocumentManagerViewModel();
            viewModel.User = CurrentUser;

            return View(viewModel);
        }
    }
}
