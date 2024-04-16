using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WatchMNS.Database;
using WatchMNS.Models;

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

            using (DatabaseContext database = new DatabaseContext())
            {
                database.Client.Add(client);

                database.SaveChanges();

            }
            return RedirectToAction("CreateUser");
        }
    }
}
