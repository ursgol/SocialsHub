using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialsHub.Core.Models.Domains;

namespace SocialsHub.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Link> Links { get; set; }


        int SaveChanges();
    }
}
