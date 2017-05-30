using LGG.Core.Models;

namespace LGG.Core.Repositories
{
    public interface IPostTagRepository
    {
        PostTag Add(PostTag map);
        void RemoveByCompound(PostTag map);
    }
}
