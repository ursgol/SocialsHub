using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialsHub.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
           Links = new Collection<Link>();
        }


        public string Content { get; set; }
        public string Name { get; set; }
      
        public ICollection<Link> Links { get; set; }
    


    }
}
