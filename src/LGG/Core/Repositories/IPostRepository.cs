using LGG.Core.Dtos;
using LGG.Core.Models;
using System.Collections.Generic;

namespace LGG.Core.Repositories
{
    public interface IPostRepository
    {
        int GetTotalNumberOfPosts();
        int GetTotalNumberOfPostsByCategory(string category);
        int GetTotalNumberOfPostByTag(string tag);
        Post GetByUrl(string url, bool includeExceprt);
        Post GetById(int id, bool includeExceprt);
        IEnumerable<Post> GetTop(int top);
        IEnumerable<Post> GetAll(bool includeExcerpt, bool includeArticle, bool includeUnpublished);
        IEnumerable<Post> GetAllPaged(int count, int page = 1, bool includeUnpublished = false);
        IEnumerable<Post> GetQueryPaged(string query, int count, int page = 1);
        int GetQueryPagedCount(string query);
        IEnumerable<Post> GetAllByTagPaged(string tag, int count, int page = 1);
        IEnumerable<Post> GetAllByCategoryPaged(string category, int count, int page = 1);
        IEnumerable<Post> GetAllByCategoryName(string categoryName, int? top);
        IEnumerable<Post> GetPostsBasedOnIdCollection(List<int> postIds);
        Post GetPreviousBasedOnId(int id);
        Post GetNextBasedOnId(int id);
        Post Add(Post map);
        void Update(PostDto post);
        void Remove(string url);
        IEnumerable<Post> GetAllPostForAdmin();
        bool CheckTitle(string title);
    }
}
