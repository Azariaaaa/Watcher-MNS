using Microsoft.AspNetCore.Mvc;

namespace WatchMNS.Controllers
{
    public class RoleManagerController : Controller
    {
        public IActionResult RoleManager()
        {
            return View();
        }
    }
}
