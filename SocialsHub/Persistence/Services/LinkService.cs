using Microsoft.EntityFrameworkCore;
using SocialsHub.Core;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Services;
using System.Linq;

namespace SocialsHub.Persistence.Services
{
    public class LinkService : ILinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LinkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Link> GetLinks(string username)
        {
            return _unitOfWork.Links.GetLinks(username);
        }
        
        public IEnumerable<Link> GetLinks()
        {
            return _unitOfWork.Links.GetLinks();
        }

       public IEnumerable<Link> Get(string userId, string Name = null, string Email = null)
        {
            return _unitOfWork.Links.Get(userId, Name, Email);
        }


        public Link Get(int id, string userId)
        {
            return _unitOfWork.Links.Get(id, userId);
        }

        public void Add(Link link)
        {
            _unitOfWork.Links.Add(link);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Links.Delete(id, userId);
            _unitOfWork.Complete();
        }

        public void Activate(int id, string userId)
        {
            _unitOfWork.Links.Activate(id, userId);
            _unitOfWork.Complete();
        }


        public void Update(Link link)
        {
            _unitOfWork.Links.Update(link);
            _unitOfWork.Complete();
        }


    }
}
