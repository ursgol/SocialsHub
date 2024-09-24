using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Services;
using SocialsHub.Core.ViewModels;
using SocialsHub.Persistence.Services;
using System.Diagnostics;
using System.Security.Claims;

namespace SocialsHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<ApplicationUser>   _userManager;
        private ILinkService _linkService;



        public HomeController(ILogger<HomeController> logger, ILinkService linkservice, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _linkService = linkservice;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Links/{username}")]
        public IActionResult Links(string username)
        {
            ViewBag.Name = username;
            var links = _linkService.GetLinks(username);
            return View("_LinksUserTable", links);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users.OrderBy(x => x.Email);



            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
