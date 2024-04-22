using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    public class ClientController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            ClientRolesStatusViewModel viewModel = new ClientRolesStatusViewModel();
            viewModel.Roles = _dbContext.Role.ToList();
            viewModel.ProfessionnalStatuses = _dbContext.ProfessionnalStatus.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateUser(ClientRolesStatusViewModel viewModel)
        {
            viewModel.Roles = _dbContext.Role.ToList();
            viewModel.ProfessionnalStatuses = _dbContext.ProfessionnalStatus.ToList();

            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        Console.WriteLine(error.ErrorMessage); 
                    }
                }

                return View(viewModel);
            }
            
            using (DatabaseContext database = new DatabaseContext())
            {
                database.Client.Add(viewModel.Client);
                database.SaveChanges();
            }
            return RedirectToAction("CreateUser");
        }

        public IActionResult DisplayUser()
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                List<Client> clients = new List<Client>();
                clients = database.Client.ToList();

                return View(clients);
            }

        }
        public IActionResult DisplayUserById(int id)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                Client? client = database.Client.Where(x => x.Id == id).FirstOrDefault();
                return View(client);
            }
        }
        public IActionResult SelectUser()
        {
            List<Client> clientList = _dbContext.Client.ToList();
            return View(clientList);
        }
        public IActionResult EditUser(int id)
        {
            Client? client = _dbContext.Client.Where(x => x.Id == id).FirstOrDefault();
            return View(client);
        }

        [HttpPost]
        public IActionResult EditUser(Client model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(model);
            }
            var userToModify = _dbContext.Client.OrderBy(x => x.Id).First();
            userToModify = model;
            _dbContext.SaveChanges();

            return RedirectToAction("SelectUser");
        }
    }
}
