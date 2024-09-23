using SocialsHub.Core.Models.Domains;

namespace SocialsHub.Core.Services
{
    public interface ILinkService
    {
        IEnumerable<Link> GetLinks();
        void Add(Link link);
        IEnumerable<Link> Get(string userId, string Name = null, string Email = null);
        void Delete(int id, string userId);
        void Update(Link link);

        Link Get(int id, string userId);

        void Activate(int id, string userId);
    }
}
