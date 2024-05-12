using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

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

        public IActionResult DelayManager()
        {
            string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client client = _dbContext.Client.FirstOrDefault(x => x.Id == clientId);

            if (client == null)
            {
                return NotFound();
            }

            var result = _dbContext.LateMiss
                .Where(x => x.Client == client && x.LateMissType == "Retard")
                .Include(x => x.lateMissStatus)
                .ToList();

            var viewModel = new DelayDeclarationViewModel
            {
                lateMissesList = result.Select(x => new LateMiss
                {
                    Id = x.Id,
                    lateMissStatus = x.lateMissStatus,
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DelayManager(DelayDeclarationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/UserPanel/DelayManager.cshtml", viewModel);
            }

            _dbContext.SaveChanges();

            return View();
        }

    }
}
