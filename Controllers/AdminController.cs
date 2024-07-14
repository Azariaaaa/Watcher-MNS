using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.DTO;
using WatchMNS.Models;
using WatchMNS.Services;
using WatchMNS.Services.Interfaces;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }
        private readonly IClientService _clientService;
        private readonly IProfessionnalStatusService _professionnalStatusService;

        public AdminController(UserManager<Client> userManager, RoleManager<IdentityRole> roleManager, IClientService clientService, IProfessionnalStatusService professionnalStatusService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _clientService = clientService;
            _professionnalStatusService = professionnalStatusService;
        }
        public async Task<IActionResult> ManageRole(string id)
        {
            AdminEditRoleViewModel viewModel = new AdminEditRoleViewModel();

            Client? client = await _clientService.GetByIdAsync(id);

            viewModel.ClientId = id;
            viewModel.ClientLastname = client.Lastname;
            viewModel.ClientFirstname = client.Firstname;

            if (client != null)
            {
                var clientRole = await _userManager
                .GetRolesAsync(client);

                viewModel.Role = clientRole;
            }


            viewModel.ExistingRoles = _roleManager.Roles.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRole(AdminEditRoleViewModel viewModel)
        {
            if(viewModel.ClientId != null)
            {
                Client? client = await _userManager.FindByIdAsync(viewModel.ClientId);
                IList<string> CurrentUserRole = await _userManager.GetRolesAsync(client);
                await _userManager.RemoveFromRolesAsync(client, CurrentUserRole);
                await _userManager.AddToRoleAsync(client, viewModel.NewRoleName);
            }

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        public async Task<IActionResult> AdminEditUser(string id)
        {

            Client? client = await _userManager.FindByIdAsync(id);

            List<ProfessionnalStatus> professionnalStatusesList = await _professionnalStatusService.GetAllAsync();

            AdminEditUserViewModel viewModel = new AdminEditUserViewModel
            {
                Id = id,
                UserToEdit = client,
                professionnalStatuses = professionnalStatusesList
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdminEditUser(string id, AdminEditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Client? client = await _userManager.FindByIdAsync(id);

            if(client != null)
            {
                client.Firstname = viewModel.UserToEdit.Firstname;
                client.Lastname = viewModel.UserToEdit.Lastname;
                client.Email = viewModel.UserToEdit.Email;
                client.Address = viewModel.UserToEdit.Address;
                client.PostCode = viewModel.UserToEdit.PostCode;
                client.City = viewModel.UserToEdit.City;
                client.Country = viewModel.UserToEdit.Country;
                client.BirthDate = viewModel.UserToEdit.BirthDate;
                client.PhoneNumber = viewModel.UserToEdit.PhoneNumber;
                client.NativeCity = viewModel.UserToEdit.NativeCity;
                client.NativeCountry = viewModel.UserToEdit.NativeCountry;
                client.ProfessionnalStatusId = viewModel.UserToEdit.ProfessionnalStatusId;

                await _userManager.UpdateAsync(client);

            }

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        public async Task<IActionResult> AdminAbsenceManager(string id)
        {
            Client? client = await _clientService.GetByIdAsync(id);

            return new ContentResult { Content = "Client ID cannot be null or empty.", ContentType = "text/plain", StatusCode = 400 };

            if (client == null)
            {
                return NotFound(404);
            }

            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Absence"))
                .Include(x => x.lateMissStatus)
                .ToList();

            var newLateMiss = new LateMiss();

            var viewModel = new AdminAbsenceDeclarationViewModel
            {
                User = client,
                ExistingLateMisses = existingLateMisses,
                NewLateMiss = newLateMiss
            };

            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> AdminAbsenceManager(AdminAbsenceDeclarationViewModel viewModel)
        {
            Client? client = _dbContext.Client
                .FirstOrDefault(x => x.Id == viewModel.User.Id);

            viewModel.NewLateMiss.Client = client;
            viewModel.NewLateMiss.DeclarationDate = DateTime.Now.Date;
            viewModel.NewLateMiss.LateMissType = "Absence";
            viewModel.NewLateMiss.StartDate = DateTime.Today.AddHours(8);
            viewModel.NewLateMiss.lateMissStatus = _dbContext.LateMissStatus
                .Where(lms => lms.Label == "Traité")
                .FirstOrDefault();


            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Absence"))
                .Include(x => x.lateMissStatus)
                .ToList();

            viewModel.ExistingLateMisses = existingLateMisses;

            _dbContext.LateMiss.Add(viewModel.NewLateMiss);
            _dbContext.SaveChanges();

            return RedirectToAction("AdminPanel", "AdminPanel");
        }


        public async Task<IActionResult> AdminDelayManager(string id)
        {
            Client? client = _dbContext.Client
               .FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Retard"))
                .Include(x => x.lateMissStatus)
                .ToList();

            var newLateMiss = new LateMiss();

            var viewModel = new AdminDelayDeclarationViewModel
            {
                User = client,
                ExistingLateMisses = existingLateMisses,
                NewLateMiss = newLateMiss
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdminDelayManager(AdminDelayDeclarationViewModel viewModel)
        {
            Client? client = _dbContext.Client
                .FirstOrDefault(x => x.Id == viewModel.User.Id);

            viewModel.NewLateMiss.Client = client;
            viewModel.NewLateMiss.DeclarationDate = DateTime.Now.Date;
            viewModel.NewLateMiss.LateMissType = "Retard";
            viewModel.NewLateMiss.StartDate = DateTime.Today.AddHours(8);
            viewModel.NewLateMiss.lateMissStatus = _dbContext.LateMissStatus
                .Where(lms => lms.Label == "Traité")
                .FirstOrDefault();


            var existingLateMisses = _dbContext.LateMiss
                .Where(x => (x.Client == client) && (x.LateMissType == "Retard"))
                .Include(x => x.lateMissStatus)
                .ToList();

            viewModel.ExistingLateMisses = existingLateMisses;

            _dbContext.LateMiss.Add(viewModel.NewLateMiss);
            _dbContext.SaveChanges();

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        public async Task<IActionResult> CreateProfessionnalStatus()
        {
            var existingProfessionnalStatuses = _dbContext.ProfessionnalStatus.ToList();
            CreateProfessionnalStatusViewModel viewModel = new CreateProfessionnalStatusViewModel();

            viewModel.existingProfessionnalStatuses = existingProfessionnalStatuses;
            

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessionnalStatus(CreateProfessionnalStatusDTO dto)
        {
            if (!ModelState.IsValid)
            {
                CreateProfessionnalStatusViewModel viewModel = new CreateProfessionnalStatusViewModel();
                var existingProfessionnalStatuses = _dbContext.ProfessionnalStatus.ToList();
                viewModel.existingProfessionnalStatuses = existingProfessionnalStatuses;
                viewModel.ProfessionnalStatus = dto.ProfessionnalStatus;

                return View(viewModel);
            }

            _dbContext.ProfessionnalStatus.Add(dto.ProfessionnalStatus);
            _dbContext.SaveChanges();

            return RedirectToAction("CreateProfessionnalStatus", "Admin");

        }
        public async Task<IActionResult> DeleteProfessionnalStatus(int id)
        {
            ProfessionnalStatus? professionnalStatusToDelete = _dbContext.ProfessionnalStatus.Where(ps => ps.Id == id).FirstOrDefault();

            if (professionnalStatusToDelete != null)
            {
                _dbContext.Remove(professionnalStatusToDelete);
                _dbContext.SaveChanges();

                return RedirectToAction("CreateProfessionnalStatus", "Admin");
            }

            return RedirectToAction("CreateProfessionnalStatus", "Admin");

        }

        public async Task<IActionResult> AdminDocumentManager(string id)
        {
            Client? user = _dbContext.Client
                .FirstOrDefault(c => c.Id == id);

            List<Document> documentList = _dbContext.Document
                .Where(d => d.Client == user)
                .Include(d => d.DocumentStatus)
                .Include(d => d.DocumentType)
                .ToList();

            Dictionary<Document, string> DocumentsWithExtensions = new Dictionary<Document, string>();

            foreach (Document document in documentList)
            {
                string extension = Path.GetExtension(document.Path);
                DocumentsWithExtensions.Add(document, extension);
            }

            AdminDocumentManagerViewModel viewModel = new AdminDocumentManagerViewModel
            {
                User = user,
                Documents = documentList,
                DocumentsWithExtensions = DocumentsWithExtensions
            };

            return View(viewModel);
        }

        


    }
}
