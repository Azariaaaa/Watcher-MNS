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

            var clients = _dbContext.Client.ToList();
            var lateMisses = _dbContext.LateMiss.ToList();

            foreach (var client in clients)
            {
                int absenceCount = _dbContext.LateMiss.Count(lm => lm.Client.Id == client.Id && lm.LateMissType == "Absence");
                int delayCount = _dbContext.LateMiss.Count(lm => lm.Client.Id == client.Id && lm.LateMissType == "Retard");
                viewModel.ClientsData.Add(client, [absenceCount, delayCount]);
            }

            viewModel.LateMisses = lateMisses;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AdminPanel(AdminPanelViewModel viewModel)
        {
            var clients = _dbContext.Client.ToList();
            var lateMisses = _dbContext.LateMiss.ToList();

            foreach (var client in clients)
            {
                int absenceCount = _dbContext.LateMiss
                    .Count(lm => lm.Client.Id == client.Id && lm.LateMissType == "Absence");

                int delayCount = _dbContext.LateMiss
                    .Count(lm => lm.Client.Id == client.Id && lm.LateMissType == "Retard");

                viewModel.ClientsData[client] = [absenceCount, delayCount];
            }

            switch (viewModel.SortOrder)
            {
                case "default":
                    viewModel.ClientsData = viewModel.ClientsData
                        .OrderBy(cd => cd.Key.Lastname)
                        .ToDictionary(cd => cd.Key, cd => cd.Value);
                    break;
                case "name_desc":
                    viewModel.ClientsData = viewModel.ClientsData
                        .OrderByDescending(cd => cd.Key.Lastname)
                        .ToDictionary(cd => cd.Key, cd => cd.Value);
                    break;
                case "absence_desc":
                    viewModel.ClientsData = viewModel.ClientsData
                        .OrderByDescending(cd => cd.Value[0])
                        .ToDictionary(cd => cd.Key, cd => cd.Value);
                    break;
                case "delay_desc":
                    viewModel.ClientsData = viewModel.ClientsData
                        .OrderByDescending(cd => cd.Value[1])
                        .ToDictionary(cd => cd.Key, cd => cd.Value);
                    break;
                default:
                    break;
            }

            viewModel.LateMisses = lateMisses;

            return View(viewModel);
        }

    }
}
