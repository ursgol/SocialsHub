using Microsoft.AspNetCore.Mvc;

namespace SocialsHub.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
