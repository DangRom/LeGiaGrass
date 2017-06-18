using LGG.Core.Dtos;
using System.Collections.Generic;

namespace LGG.Core.Services
{
    public interface IPostService
    {
        int GetTotalNumberOfPosts();
        int GetTotalNumberOfPostsByCategory(string category);
        int GetTotalNumberOfPostByTag(string tag);
        PostDto GetById(int id, bool includeExceprt = false);
        PostDto GetByUrl(string url, bool includeExceprt = false);
        IEnumerable<PostDto> GetAll(bool includeExcerpt = true, bool includeArticle = true, bool includeUnpublished = false, int? top = null);
        IEnumerable<PostDto> GetAllPaged(int count, int page = 1, bool includeUnpublished = false);
        IEnumerable<PostDto> GetAllByTag(string tag, int count, int page = 1);
        IEnumerable<PostDto> GetAllByCategory(string category, int count, int page = 1);
        IEnumerable<PostDto> GetAllByCategoryName(string categoryName, int? top = null);
        IEnumerable<PostDto> GetPopularPosts();
        IEnumerable<PostDto> GetPreviousCurrentNextPost(string id);
        PostDto Add(PostDto post);
        void Update(PostDto item);
        void Remove(string id);
        IEnumerable<PostDto> GetAllPostForAdmin();
        bool CheckTitle(string title);
    }

}
