using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            Console.WriteLine("ModelState Valide");

            using (DatabaseContext database = new DatabaseContext())
            {
                database.Client.Add(client);
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

    }
}
