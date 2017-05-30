using LGG.Core.Helpers;

namespace LGG.Core.Services
{
    public interface ISearchService
    {
        SearchResults SearchPosts(string query, int count, int page = 1);
    }
}
