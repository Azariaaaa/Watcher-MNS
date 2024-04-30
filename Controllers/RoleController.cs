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
    }
}
