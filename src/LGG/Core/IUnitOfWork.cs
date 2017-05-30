using LGG.Core.Repositories;

namespace LGG.Core
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }

        void Complete();
    }
}
