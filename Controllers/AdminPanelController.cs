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

        [HttpPost]
        public IActionResult AdminPanel(AdminPanelViewModel viewModel)
        {
            var clients = _dbContext.Client
                .ToList();
            var lateMisses = _dbContext.LateMiss
                .ToList();
            Console.WriteLine(viewModel.SortOrder);
            switch (viewModel.SortOrder)
            {
                case "default":
                    clients.OrderBy(c => c.Lastname).ToList(); 
                    break;
                case "name_desc":
                    clients.OrderByDescending(c => c.Lastname).ToList();
                    break;
                default:
                    break;
            }

            viewModel.Clients = clients;
            viewModel.LateMisses = lateMisses;
            Console.WriteLine(viewModel.SortOrder);
            Console.WriteLine(clients[0].Lastname);

            return View(viewModel);
        }

    }
}
