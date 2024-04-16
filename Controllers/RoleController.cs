using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            using (DatabaseContext database = new DatabaseContext())
            {
                database.Role.Add(role);

                database.SaveChanges();
            }

            return RedirectToAction("CreateRole");
        }
    }
}
