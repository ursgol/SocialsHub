using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialsHub.Core;
using SocialsHub.Core.Models;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Repositories;
using SocialsHub.Persistence.Repositories;
using SocialsHub.Persistence.Services;

namespace SocialsHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UnitOfWork(IApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            Links = new LinkRepository(context, userManager);


        }

        public ILinkRepository Links { get; set; }



        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
