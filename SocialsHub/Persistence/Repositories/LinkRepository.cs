using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Versioning;
using SocialsHub.Core;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Repositories;
using System.Linq;

namespace SocialsHub.Persistence.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private IApplicationDbContext _context;
        private  UserManager<ApplicationUser> _userManager; 

        public LinkRepository(IApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<Link> GetLinks(string username)
        {
            var user = _userManager.Users.Single(x => x.Name == username);
           
            var links = _context.Links.Where(x => x.UserId == user.Id);

            return links.ToList();

        }






        public IEnumerable<Link> GetLinks()
        {
            return _context.Links.ToList();
        }
        public IEnumerable<Link> Get(string userId, string Name= null,string Email = null)
        {
            var links = _context.Links.Where(x => x.UserId == userId);

            if (!string.IsNullOrWhiteSpace(Name))
                links = links.Where(x => x.User.UserName.Contains(Name));


            if (!string.IsNullOrWhiteSpace(Email))
                links = links.Where(x => x.User.Email.Contains(Email));

            return links.OrderBy(x => x.UserId).ToList();

        }

        public Link Get(int id, string userId)
        {
            var link = _context.Links
               .Single(x => x.Id == id && x.UserId == userId);

            return link;
        }

        public void Add(Link link)
        {
            if (link.Url== null && link.Name==null)
                return;

            _context.Links.Add(link);

        }

        public void Delete(int id, string userId)
        {
            var adToDelete = _context.Links.Single(x => x.Id == id && x.UserId == userId);
            _context.Links.Remove(adToDelete);
        }

        public void Update(Link link)
        {
            var adToUpdate = _context.Links.Single(x => x.Id == link.Id);

            adToUpdate.Url = link.Url;
            adToUpdate.Name = link.Name;
            adToUpdate.IsActive = link.IsActive;
            

        }

        public void Activate(int id, string userId)
        {
            var linkToUpdate = _context.Links.Single(x => x.Id == id && x.UserId == userId);
            switch (linkToUpdate.IsActive)
            {
                case true:
                    linkToUpdate.IsActive = false;
                    break;
                case false: 
                    linkToUpdate.IsActive = true;
                    break;
                default:
                    linkToUpdate.IsActive = true;
                    break;
            }



            
            
        }
    }
}
