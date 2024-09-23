using SocialsHub.Core.Models;
using SocialsHub.Core.Models.Domains;
using System.Collections.ObjectModel;

namespace SocialsHub.Core.ViewModels
{
    public class LinksViewModel
    {
      
        public ICollection<Link> Links { get; set; }

        public FilterProfiles FilterProfiles { get; set; }

    }
}
