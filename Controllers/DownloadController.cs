using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata;
using WatchMNS.Database;
using WatchMNS.DTO;
using WatchMNS.Models;
using WatchMNS.ViewModel;

namespace WatchMNS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DownloadController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public IActionResult Download(int? id)
        {
            Models.Document? document = new Models.Document();
            document = _dbContext.Document.Find(id);

            return File(document.Path, document.Label);
        }
    }
}
