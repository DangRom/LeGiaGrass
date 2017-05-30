using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using System.Linq;

namespace LGG.Persistence.Services
{
    public class SearchService : ISearchService
    {
        private readonly IPostRepository _postRepository;

        public SearchService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public SearchResults SearchPosts(string query, int count, int page = 1)
        {
            var searchResults = new SearchResults();

            if (string.IsNullOrEmpty(query)) return searchResults;

            searchResults.Posts = _postRepository.GetQueryPaged(query, count, page).Select(Mapper.Map<Post, PostDto>).ToList();
            searchResults.TotalMatchingPosts = _postRepository.GetQueryPagedCount(query);

            return searchResults;
        }
    }
}
