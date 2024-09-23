using SocialsHub.Core.Models.Domains;
using System.Collections.ObjectModel;

namespace SocialsHub.Core.ViewModels
{
    public class LinkViewModel
    {
        public LinkViewModel()
        {
            Links = new Collection<Link>();
        }
        public string Heading { get; set; }
        public Link Link { get; set; }
        public ICollection<Link> Links { get; set; }

    }
}
