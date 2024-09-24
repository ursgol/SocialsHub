using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialsHub.Core.Models;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Services;
using SocialsHub.Core.ViewModels;
using SocialsHub.Persistence.Extensions;
using System.Security.Claims;

namespace SocialsHub.Controllers
{

    public class LinkController : Controller
    {
        private ILinkService _linkService;
        private UserManager<ApplicationUser> _userManager;

        public LinkController(ILinkService linkService, UserManager<ApplicationUser> userManager)
        {
            _linkService = linkService;
            _userManager = userManager;
        }


     
        




        [AllowAnonymous]
        public IActionResult Links()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var vm = new LinksViewModel
            {
                FilterProfiles = new FilterProfiles(),
                Links =(ICollection<Link>)_linkService.Get(userId)
            };
            return View(vm);
        }



        [Authorize]
        public IActionResult Themes()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return View();
        }

       


        [Authorize]
        public IActionResult MyLinks(LinksViewModel viewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var links = (ICollection<Link>)_linkService.Get(userId);
           

            return View(links);
        }




        [HttpPost]
        public IActionResult Links(LinksViewModel viewModel)
        {
            var userId = User.GetUsetId();
            var links = _linkService.Get(userId, viewModel.FilterProfiles.Name, viewModel.FilterProfiles.Email);


            return PartialView("_LinksTable", links);
        }

        [Authorize]

        public IActionResult Link(int id = 0)
        {
            var userId = User.GetUsetId();
            var link = id==0 ? new Link { Id=0, UserId = userId} :
               _linkService.Get(id, userId);

            var vm = new LinkViewModel
            {
                Link = link,
                Heading = id == 0 ?
                "Dodawanie nowego linka" : "Edytowanie linka",
            };

            return View(vm);

        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Link(Link link)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            link.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new LinkViewModel
                {
                    Link = link,
                    Heading = link.Id == 0 ?
                "Dodawanie nowego linka" : "Edytowanie linka",
                };
                return View("Link", vm);
            }

            if (link.Id == 0)
            {
                _linkService.Add(link);

            }
            else
            {
                _linkService.Update(link);

            }



            return RedirectToAction("MyLinks");

        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUsetId();
                _linkService.Delete(id, userId);


            }
            catch (Exception ex)
            {
                //log
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });

        }


        [HttpPost]
        public IActionResult Activate(int id)
        {
            try
            {
                var userId = User.GetUsetId();
                _linkService.Activate(id, userId);

            }
            catch (Exception ex)
            {
                //log
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });

        }


    }
}
