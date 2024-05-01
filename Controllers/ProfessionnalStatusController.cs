using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchMNS.Database;
using WatchMNS.Models;

namespace WatchMNS.Controllers
{
    [Authorize]
    public class ProfessionnalStatusController : Controller
    {
        public IActionResult CreateProfessionnalStatus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfessionnalStatus(ProfessionnalStatus pStatus)
        {
            if(!ModelState.IsValid)
            {
                return View(pStatus);
            }

            using (DatabaseContext database = new DatabaseContext())
            {
                database.ProfessionnalStatus.Add(pStatus);

                database.SaveChanges();
            }

            return RedirectToAction("CreateProfessionnalStatus");

        }
    }
}
