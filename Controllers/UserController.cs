using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> DocumentManager()
        {
            string? currentUserId = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            Client? currentUser = _dbContext.Client
                .Where(u  => u.Id == currentUserId)
                .FirstOrDefault();

            List<Document> userDocumentList = _dbContext.Document
                .Where(d => d.Client == currentUser)
                .Include(d => d.DocumentType)
                .ToList();

            List<DocumentType> documentTypeList = _dbContext.DocumentType
                .ToList();

            int UserDocumentsCount = userDocumentList
                .Count();

            UserDocumentManagerViewModel viewModel = new UserDocumentManagerViewModel();
            viewModel.User = currentUser;
            viewModel.UserDocumentCount = UserDocumentsCount;
            viewModel.Documents = userDocumentList;
            viewModel.DocumentTypes = documentTypeList;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> DocumentManager(UserDocumentManagerDTO dto)
        {
            string? currentUserId = User
               .FindFirstValue(ClaimTypes.NameIdentifier);

            Client? currentUser = _dbContext.Client
                .Where(u => u.Id == currentUserId)
                .FirstOrDefault();

            DocumentType? documentType = _dbContext.DocumentType
                .Where(dt => dt.Label == dto.DocumentType)
                .FirstOrDefault();

            Document document = new Document();

            document.Label = dto.DocumentName;
            document.Path = "/Files/" + dto.DocumentName + ".png";
            document.UploadDate = DateTime.Now;
            document.LastStatusDate = DateTime.Now;
            document.Client = currentUser;
            document.DocumentStatus = _dbContext.DocumentStatus.Where(ds => ds.Label == "En attente de validation").FirstOrDefault();
            document.DocumentType = documentType;

            if(!ModelState.IsValid)
            {
                List<Document> userDocumentList = _dbContext.Document
                    .Where(d => d.Client == currentUser)
                    .Include(d => d.DocumentType)
                    .ToList();

                List<DocumentType> documentTypeList = _dbContext.DocumentType
                    .ToList();

                int userDocumentsCount = userDocumentList.Count();

                UserDocumentManagerViewModel viewModel = new UserDocumentManagerViewModel();
                viewModel.User = currentUser;
                viewModel.DocumentName = dto.DocumentName;
                viewModel.Documents = userDocumentList;
                viewModel.UserDocumentCount = userDocumentsCount;
                viewModel.DocumentTypes = documentTypeList;
                viewModel.DocumentType = documentType;

                return View(viewModel);
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new FileInfo(dto.DocumentName);
            string fileName = dto.DocumentName + ".png"; // ICI PAS OUF A REFAIRE
            string fileNameWithPath = Path.Combine(path, fileName);

            

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                dto.File.CopyTo(stream);
            }
            _dbContext.Document.Add(document);
            _dbContext.SaveChanges();

            return RedirectToAction("DocumentManager");
        }
    }
}
