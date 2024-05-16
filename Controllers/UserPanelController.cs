using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    [Authorize(Roles = "User")]
    public class UserPanelController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }

        public UserPanelController(UserManager<Client> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Panel()
        {
            string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client? client = _dbContext.Client.Where(x => x.Id == clientId).FirstOrDefault();
            return View(client);
        }

        public IActionResult DelayManager()
        {
            string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client client = _dbContext.Client.FirstOrDefault(x => x.Id == clientId);

            if (client == null)
            {
                return NotFound();
            }

            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Retard"))
                .Include(x => x.lateMissStatus)
                .ToList();

            var newLateMiss = new LateMiss();

            var viewModel = new DelayDeclarationViewModel
            {
                ExistingLateMisses = existingLateMisses,
                NewLateMiss = newLateMiss
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DelayManager(DelayDeclarationViewModel viewModel)
        {
            string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client client = _dbContext.Client.FirstOrDefault(x => x.Id == clientId);

            viewModel.NewLateMiss.Client = client;
            viewModel.NewLateMiss.DeclarationDate = DateTime.Now.Date;
            viewModel.NewLateMiss.LateMissType = "Retard";
            viewModel.NewLateMiss.StartDate = DateTime.Today.AddHours(8);
            viewModel.NewLateMiss.lateMissStatus = _dbContext.LateMissStatus.Where(lms => lms.Label == "En Attente").FirstOrDefault();
            

            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Retard"))
                .Include(x => x.lateMissStatus)
                .ToList();

            viewModel.ExistingLateMisses = existingLateMisses;

            //if (!ModelState.IsValid)
            //{
            //    return View(viewModel);
            //}
            
            _dbContext.LateMiss.Add(viewModel.NewLateMiss);
            _dbContext.SaveChanges();

            return RedirectToAction("DelayManager");
        }

        public IActionResult AbsenceManager()
        {
            string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client client = _dbContext.Client.FirstOrDefault(x => x.Id == clientId);

            if (client == null)
            {
                return NotFound();
            }

            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Absence"))
                .Include(x => x.lateMissStatus)
                .ToList();

            var newLateMiss = new LateMiss();

            var viewModel = new AbsenceDeclarationViewModel
            {
                ExistingLateMisses = existingLateMisses,
                NewLateMiss = newLateMiss
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AbsenceManager(AbsenceDeclarationViewModel viewModel)
        {
            string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client client = _dbContext.Client.FirstOrDefault(x => x.Id == clientId);

            viewModel.NewLateMiss.Client = client;
            viewModel.NewLateMiss.DeclarationDate = DateTime.Now.Date;
            viewModel.NewLateMiss.LateMissType = "Absence";
            viewModel.NewLateMiss.StartDate = DateTime.Today.AddHours(8);
            viewModel.NewLateMiss.lateMissStatus = _dbContext.LateMissStatus.Where(lms => lms.Label == "En Attente").FirstOrDefault();


            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Absence"))
                .Include(x => x.lateMissStatus)
                .ToList();

            viewModel.ExistingLateMisses = existingLateMisses;

            //if (!ModelState.IsValid)
            //{
            //    return View(viewModel);
            //}

            _dbContext.LateMiss.Add(viewModel.NewLateMiss);
            _dbContext.SaveChanges();

            return RedirectToAction("AbsenceManager");
        }
    }
}
