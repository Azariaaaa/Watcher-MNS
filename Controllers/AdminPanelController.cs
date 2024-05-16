using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }

        public AdminPanelController(UserManager<Client> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult AdminPanel()
        {
            AdminPanelViewModel viewModel = new AdminPanelViewModel();

            var clients = _dbContext.Client
                .ToList();
            var lateMisses = _dbContext.LateMiss
                .ToList();   

            viewModel.Clients = clients;
            viewModel.LateMisses = lateMisses;

            return View(viewModel);
        }
    }
}
