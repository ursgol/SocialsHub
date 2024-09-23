using SocialsHub.Core.Models.Domains;

namespace SocialsHub.Core.Repositories
{
    public interface ILinkRepository
    {
        IEnumerable<Link> GetLinks();

        IEnumerable<Link> Get(string userId, string Name = null, string Email = null);
        Link Get(int id, string userId);

        void Add(Link link);

        void Delete(int id, string userId);
        void Activate(int id, string userId);

        void Update(Link link);
    }
}
