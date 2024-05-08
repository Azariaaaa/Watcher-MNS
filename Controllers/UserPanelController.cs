using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Controllers
{
    [Authorize(Roles = "User")]
    public class UserPanelController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }

        public UserPanelController(UserManager<Client> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Panel()
        {
            string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client? client = _dbContext.Client.Where(x => x.Id == clientId).FirstOrDefault();
            return View(client);
        }
    }
}
