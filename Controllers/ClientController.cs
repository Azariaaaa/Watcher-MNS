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
            Console.WriteLine("test");
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(Client client)
        {
            Console.WriteLine("entre dans la method");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model non valid");
                return View(client);
            }

            Console.WriteLine("Passe le model");
            using (DatabaseContext database = new DatabaseContext())
            {
                database.Client.Add(client);

                database.SaveChanges();

            }
            return RedirectToAction("CreateUser");
        }



    }
}
