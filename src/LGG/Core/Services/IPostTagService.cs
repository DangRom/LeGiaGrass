using LGG.Core.Dtos;

namespace LGG.Core.Services
{
    public interface IPostTagService
    {
        PostTagDto Add(PostTagDto postTag);
        void Delete(PostTagDto postTag);
    }
}
