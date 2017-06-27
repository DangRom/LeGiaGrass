using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IOptions<AppConfiguration> _appConfiguration;

        public PostService(IPostRepository postRepository,
            IOptions<AppConfiguration> appConfiguration)
        {
            _postRepository = postRepository;
            _appConfiguration = appConfiguration;
        }

        /// <summary>
        /// Get total number of posts
        /// </summary>
        public int GetTotalNumberOfPosts()
        {
            return _postRepository.GetTotalNumberOfPosts();
        }

        /// <summary>
        /// Get total number of posts by category
        /// </summary>
        /// <param name="category">category url</param>
        public int GetTotalNumberOfPostsByCategory(string category)
        {
            return _postRepository.GetTotalNumberOfPostsByCategory(category);
        }

        /// <summary>
        /// Get total number of posts by tag
        /// </summary>
        /// <param name="tag">tag url</param>
        public int GetTotalNumberOfPostByTag(string tag)
        {
            return _postRepository.GetTotalNumberOfPostByTag(tag);
        }

        /// <summary>
        /// Get PostDto by url
        /// </summary>
        /// <param name="url">URL of post</param>
        /// <param name="includeExcerpt">Include excerpt</param>
        /// <returns>Post</returns>
        public PostDto GetByUrl(string url, bool includeExcerpt = false)
        {
            return Mapper.Map<Post, PostDto>(_postRepository.GetByUrl(url, includeExcerpt));
        }

        /// <summary>
        /// Get Post by id
        /// </summary>
        /// <param name="id">Id of post</param>
        /// <param name="includeExcerpt">Include excerpt</param>
        /// <returns>PostDto</returns>
        public PostDto GetById(int id, bool includeExcerpt = false)
        {
            return Mapper.Map<Post, PostDto>(_postRepository.GetById(id, includeExcerpt));
        }

        /// <summary>
        /// Get all posts or get top posts
        /// </summary>
        /// <param name="includeExcerpt">Include Excerpt</param>
        /// <param name="includeArticle">Include Article</param>
        /// <param name="includeUnpublished">Include Unpublished</param>
        /// <param name="top">Take top.  If null returns all posts</param>
        /// <returns>Collection of Post</returns>
        public IEnumerable<PostDto> GetAll(bool includeExcerpt = true,
            bool includeArticle = true,
            bool includeUnpublished = false,
            int? top = null)
        {
            var posts = top != null
                ? _postRepository.GetTop((int)top).ToList()
                : _postRepository.GetAll(includeExcerpt, includeArticle, includeUnpublished)
                    .OrderByDescending(x => x.PostedOn)
                    .ToList();

            return posts.Select(Mapper.Map<Post, PostDto>);
        }

        /// <summary>
        /// Get paged collection of posts
        /// </summary>
        /// <param name="count">Number of posts in page</param>
        /// <param name="page">Page of posts</param>
        /// <param name="includeUnpublished"></param>
        /// <returns>Count of posts starting at page</returns>
        public IEnumerable<PostDto> GetAllPaged(int count, int page = 1, bool includeUnpublished = false)
        {
            return _postRepository.GetAllPaged(count, page, includeUnpublished).Select(Mapper.Map<Post, PostDto>);
        }

        /// <summary>
        /// Get paged collection of posts, filtered by tag
        /// </summary>
        /// <param name="tag">Filter by tag</param>
        /// <param name="count">Number of posts in page</param>
        /// <param name="page">Page of posts</param>
        /// <returns>Count of posts starting at page</returns>
        public IEnumerable<PostDto> GetAllByTag(string tag, int count, int page = 1)
        {
            return Mapper.Map<IList<Post>, IList<PostDto>>(_postRepository.GetAllByTagPaged(tag, count, page).ToList());
        }

        /// <summary>
        /// Get paged collection of posts, filtered by category
        /// </summary>
        /// <param name="category">Filter by category</param>
        /// <param name="count">Number of posts in page</param>
        /// <param name="page">Page of posts</param>
        /// <returns>Count of posts starting at page</returns>
        public IEnumerable<PostDto> GetAllByCategory(string category, int count, int page = 1)
        {
            return Mapper.Map<IList<Post>, IList<PostDto>>(_postRepository.GetAllByCategoryPaged(category, count, page).ToList());
        }


        public IEnumerable<PostDto> GetAllByCategoryName(string categoryName, int? top = null)
        {
            return Mapper.Map<IList<Post>, IList<PostDto>>(_postRepository.GetAllByCategoryName(categoryName, top).ToList());
        }

        /// <summary>
        /// Get popular post based on ids in app settings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PostDto> GetPopularPosts()
        {
            return Mapper.Map<IList<Post>, IList<PostDto>>(_postRepository.GetPostsBasedOnIdCollection(_appConfiguration.Value.PopularPosts).ToList());
        }

        /// <summary>
        /// Get Previous, Current and Next post based on id
        /// </summary>
        /// <param name="id">Current post url</param>
        /// <returns>Collection with first index being previous, second index being current and third index being next</returns>
        // TODO: Profile and work to reduce trips to the database
        public IEnumerable<PostDto> GetPreviousCurrentNextPost(string id)
        {
            var currentPost = _postRepository.GetByUrl(id, false);
            var posts = new List<Post>
            {
                _postRepository.GetPreviousBasedOnId(currentPost.PostId),
                currentPost,
                _postRepository.GetNextBasedOnId(currentPost.PostId)
            };

            return Mapper.Map<IList<Post>, IList<PostDto>>(posts);
        }

        /// <summary>
        /// Add Post record
        /// </summary>
        /// <param name="post">Post object</param>
        /// <returns>New PostDto record</returns>
        public void Add(PostDto post)
        {
            if (post.Title == null)
            {
                post.Title = Guid.NewGuid().ToString();
                post.Url = post.Title;
            }

            post.PostedOn = DateTime.Now;
            post.ModifiedOn = post.PostedOn;
            post.CreatedOn = post.PostedOn;

            _postRepository.AddPost(Mapper.Map<PostDto, Post>(post));
        }

        /// <summary>
        /// Update Post record
        /// </summary>
        /// <param name="post">PostDto Object</param>
        public void Update(PostDto post)
        {
            _postRepository.Update(post);
        }

        /// <summary>
        /// Delete Post record
        /// </summary>
        /// <param name="url">PostDto URL</param>
        public void Remove(string url)
        {
            _postRepository.Remove(url);
        }

        public IEnumerable<PostDto> GetAllPostForAdmin()
        {
            var postmodel = _postRepository.GetAllPostForAdmin();
            foreach (var p in postmodel)
            {
                var post = new PostDto
                {
                    PostId = p.PostId,
                    Url = p.Url,
                    Title = p.Title
                };
                post.Category.CategoryId = p.Category.CategoryId;
                post.Category.Name = p.Category.Name;
                post.Published = p.Published;
                yield return post;
            }
        }

        public bool CheckTitle(string title)
        {
            return _postRepository.CheckTitle(title);
        }

        public void RemoveById(int id)
        {
            _postRepository.RemoveById(id);
        }
    }
}
