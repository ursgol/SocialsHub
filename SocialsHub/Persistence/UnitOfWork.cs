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

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Links = new LinkRepository(context);


        }

        public ILinkRepository Links { get; set; }



        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
