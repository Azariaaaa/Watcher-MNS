using Microsoft.AspNetCore.Mvc;

namespace WatchMNS.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
