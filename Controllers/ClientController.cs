using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            //viewModel.Roles = _dbContext.Role.ToList();
            viewModel.ProfessionnalStatuses = _dbContext.ProfessionnalStatus.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateUser(ClientRolesStatusViewModel viewModel)
        {
            //viewModel.Roles = _dbContext.Role.ToList();
            viewModel.ProfessionnalStatuses = _dbContext.ProfessionnalStatus.ToList();

            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    ModelError? error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        Console.WriteLine(error.ErrorMessage); 
                    }
                }

                return View(viewModel);
            }
            
            
            _dbContext.Client.Add(viewModel.Client);
            _dbContext.SaveChanges();
            
            return RedirectToAction("CreateUser");
        }

        public IActionResult DisplayUser()
        {
            List<Client> clients = new List<Client>();
            clients = _dbContext.Client.ToList();

            return View(clients);

        }
        public IActionResult DisplayUserById(string id)
        {
            
            Client? client = _dbContext.Client.Where(x => x.Id == id).FirstOrDefault();
            return View(client);
        }
        public IActionResult SelectUser()
        {
            List<Client> clientList = _dbContext.Client.OrderBy(x => x.Lastname).ToList();
            return View(clientList);
        }
        public IActionResult EditUser(string id)
        {
            Client? client = _dbContext.Client.Where(x => x.Id == id).FirstOrDefault();

            UserEditUserViewModel viewModel = new UserEditUserViewModel();
            viewModel.Id = id;
            viewModel.Lastname = client.Lastname;
            viewModel.Firstname = client.Firstname;
            //viewModel.Password = client.Password;
            viewModel.Email = client.Email;
            viewModel.Address = client.Address;
            viewModel.City = client.City;
            viewModel.PostCode = client.PostCode;
            viewModel.Country = client.Country;
            //viewModel.BirthDate = client.BirthDate;
            viewModel.NativeCity = client.NativeCity;
            viewModel.NativeCountry = client.NativeCountry;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserEditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                foreach (string key in ModelState.Keys)
                {
                    ModelError? error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(viewModel);
            }

            Client? client = _dbContext.Client.Where(x => x.Id == viewModel.Id).FirstOrDefault();

            client.Lastname = viewModel.Lastname;
            client.Firstname = viewModel.Firstname;
            //client.Password = viewModel.Password;
            client.Email = viewModel.Email;
            client.Address = viewModel.Address;
            client.City = viewModel.City;
            client.PostCode = viewModel.PostCode;
            client.Country = viewModel.Country;
            client.BirthDate = viewModel.BirthDate;
            client.NativeCity = viewModel.NativeCity;
            client.NativeCountry = viewModel.NativeCountry;

            _dbContext.Client.Update(client);
            _dbContext.SaveChanges();

            return RedirectToAction("SelectUser");
        }

        public IActionResult DeleteUser(string Id)
        {
            Client? client = _dbContext.Client.Where(x => x.Id ==  Id).FirstOrDefault();
            if (client != null)
            {
                _dbContext.Client.Remove(client);
                _dbContext.SaveChanges();
                return RedirectToAction("SelectUser");
            }

            return RedirectToAction("Error");
        }
    }
}
