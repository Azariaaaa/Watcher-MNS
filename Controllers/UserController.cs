using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using WatchMNS.Database;
using WatchMNS.DTO;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private UserManager<Client> _userManager { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public UserController(UserManager<Client> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public ActionResult DocumentManager()
        {
            string? CurrentUserId = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            Client? CurrentUser = _dbContext.Client.Where(u  => u.Id == CurrentUserId).FirstOrDefault();

            UserDocumentManagerViewModel viewModel = new UserDocumentManagerViewModel();
            viewModel.User = CurrentUser;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DocumentManager(UserDocumentManagerDTO dto)
        {
            string? CurrentUserId = User
               .FindFirstValue(ClaimTypes.NameIdentifier);

            Client? CurrentUser = _dbContext.Client.Where(u => u.Id == CurrentUserId).FirstOrDefault();
            Document document = new Document();

            document.Path = "C:\\Users\\krust\\OneDrive\\Bureau\\WatchMNS - Original\\WatchMNS\\Documents\\" + dto.DocumentName;
            document.UploadDate = DateTime.Now;
            document.LastStatusDate = DateTime.Now;
            document.Client = CurrentUser;
            document.DocumentStatus = _dbContext.DocumentStatus.Where(ds => ds.Label == "En attente de validation").FirstOrDefault();
            document.DocumentType = _dbContext.DocumentType.Where(dt => dt.Label == "Carte d'identité").FirstOrDefault();

            if(!ModelState.IsValid)
            {
                UserDocumentManagerViewModel viewModel = new UserDocumentManagerViewModel();
                viewModel.User = CurrentUser;
                viewModel.DocumentName = dto.DocumentName;
                return View(viewModel);
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new FileInfo(dto.DocumentName);
            string fileName = dto.DocumentName + ".png";
            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                dto.File.CopyTo(stream);
            }
            _dbContext.Document.Add(document);

            return RedirectToAction("DocumentManager");
        }
    }
}
