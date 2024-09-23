using SocialsHub.Core.Repositories;

namespace SocialsHub.Core
{
    public interface IUnitOfWork
    {
        ILinkRepository Links { get; }


        void Complete();
    }
}
