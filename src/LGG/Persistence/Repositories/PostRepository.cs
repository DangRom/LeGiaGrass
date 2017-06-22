using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Get a count of post
        /// </summary>
        /// <returns>Number of posts</returns>
        public int GetTotalNumberOfPosts()
        {
            return _context.Posts.Count();
        }

        /// <summary>
        /// Get total number of posts by category
        /// </summary>
        /// <param name="category">category URL</param>
        /// <returns>Collection of Posts</returns>
        public int GetTotalNumberOfPostsByCategory(string category)
        {
            return _context
                    .Posts
                    .Where(x => x.Category.Url.ToLower() == category)
                    .Include(x => x.Category)
                    .Count();
        }

        /// <summary>
        /// Get total number of posts by tag
        /// </summary>
        /// <param name="tag">tag URL</param>
        /// <returns>Collection of Posts</returns>
        public int GetTotalNumberOfPostByTag(string tag)
        {
            return _context
                    .Posts
                    .Include(x => x.PostTags)
                    .Count(x => x.PostTags.Any(t => t.Tag.Url == tag));
        }

        /// <summary>
        /// Get Post by URL
        /// </summary>
        /// <param name="url">URL of post</param>
        /// <param name="includeExcerpt">Include excerpt</param>
        /// <returns>Post</returns>
        public Post GetByUrl(string url, bool includeExcerpt)
        {
            var query = _context
                .Posts
                .Where(x => true);

            if (includeExcerpt)
            {
                query = query.Include(x => x.Excerpt);
            }

            return query
                .Include(x => x.Article)
                .Include(x => x.Category)
                .Include(x => x.PostTags)
                    .ThenInclude(i => i.Tag)
                .FirstOrDefault(x => x.Url == url);
        }

        /// <summary>
        /// Get Post by id
        /// </summary>
        /// <param name="id">Id of post</param>
        /// <param name="includeExcerpt">Include excerpt</param>
        /// <returns>Post</returns>
        public Post GetById(int id, bool includeExcerpt)
        {
            var query = _context
                .Posts
                .Where(x => true);

            if (includeExcerpt)
            {
                query = query.Include(x => x.Excerpt);
            }

            return query
                .Include(x => x.Article)
                .Include(x => x.Category)
                .Include(x => x.PostTags)
                    .ThenInclude(i => i.Tag)
                .FirstOrDefault(x => x.PostId == id);
        }

        /// <summary>
        /// Get top number of posts
        /// </summary>
        /// <param name="top">Top value to Take</param>
        /// <returns>Collection of posts</returns>
        public IEnumerable<Post> GetTop(int top)
        {
            return _context.Posts
                    .Where(x => x.Published)
                    .Include(x => x.Excerpt)
                    .Include(x => x.Category)
                    .Include(x => x.PostTags)
                        .ThenInclude(i => i.Tag)
                    .OrderByDescending(x => x.PostedOn)
                    .Take(top)
                    .ToList();
        }

        /// <summary>
        /// Return all Posts
        /// </summary>
        /// <param name="includeExcerpt">Include Excerpt</param>
        /// <param name="includeArticle">Include Article</param>
        /// <param name="includeUnpublished">Include Unpublished</param>
        /// <returns>Collection of posts</returns>
        public IEnumerable<Post> GetAll(bool includeExcerpt, bool includeArticle, bool includeUnpublished)
        {
            var query = _context
                .Posts
                .Where(x => true);

            if (!includeUnpublished)
            {
                query = query.Where(x => x.Published);
            }

            if (includeExcerpt)
            {
                query = query.Include(x => x.Excerpt);
            }

            if (includeArticle)
            {
                query = query.Include(x => x.Article);
            }

            query = query.Include(x => x.Category)
                .Include(x => x.PostTags)
                    .ThenInclude(i => i.Tag)
                .OrderByDescending(x => x.PostedOn);

            return query.ToList();
        }

        /// <summary>
        /// Get a collection of pages by skipping x and taking y
        /// </summary>
        /// <param name="count">The total number of posts you want to Take</param>
        /// <param name="page">The denomination of posts you want to skip. (page - 1) * count </param>
        /// <param name="includeUnpublished"></param>
        /// <returns>Collections of posts</returns>
        public IEnumerable<Post> GetAllPaged(int count, int page = 1, bool includeUnpublished = false)
        {
            IQueryable<Post> query;

            if (!includeUnpublished)
            {
                query = _context
                    .Posts
                    .Where(x => x.Published);
            }
            else
            {
                query = _context
                    .Posts;
            }

            return query
                    .Include(x => x.Excerpt)
                    .Include(x => x.Category)
                    .Include(x => x.PostTags)
                        .ThenInclude(i => i.Tag)
                    .OrderByDescending(x => x.PostedOn)
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }

        /// <summary>
        /// Get pages posted based on query term
        /// </summary>
        /// <param name="query">Query term to search on</param>
        /// <param name="count">The total number of posts you want to Take</param>
        /// <param name="page">The denomination of posts you want to skip. (page - 1) * count </param>
        public IEnumerable<Post> GetQueryPaged(string query, int count, int page = 1)
        {
            return _context
                    .Posts
                    .Where(x => x.Published && (x.Title.Contains(query) || x.Article.Content.Contains(query)))
                        .Include(x => x.Excerpt)
                        .Include(x => x.Category)
                        .Include(x => x.PostTags)
                            .ThenInclude(i => i.Tag)
                    .OrderByDescending(x => x.PostedOn)
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }

        /// <summary>
        /// Get count base on query term
        /// </summary>
        /// <param name="query">Query term to search on</param>
        public int GetQueryPagedCount(string query)
        {
            return _context.Posts
                    .Count(x => x.Published && (x.Title.Contains(query) || x.Article.Content.Contains(query)));
        }

        /// <summary>
        /// Get a collection of pages by skipping x and taking y, filtered by tag.
        /// </summary>
        /// <param name="tag">Filter by tag</param>
        /// <param name="count">The total number of posts you want to Take</param>
        /// <param name="page">The denomination of posts you want to skip. (page - 1) * count </param>
        /// <returns>Collections of posts</returns>
        public IEnumerable<Post> GetAllByTagPaged(string tag, int count, int page = 1)
        {
            return _context
                    .Posts
                    .Where(x => x.Published)
                    .Include(x => x.Excerpt)
                    .Include(x => x.Category)
                    .Include(x => x.PostTags)
                        .ThenInclude(i => i.Tag)
                    .Where(x => x.PostTags.Any(t => t.Tag.Url.ToLower() == tag))
                    .OrderByDescending(x => x.PostedOn)
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }

        /// <summary>
        /// Get a collection of pages by skipping x and taking y, filtered by category.
        /// </summary>
        /// <param name="category">Filter by category</param>
        /// <param name="count">The total number of posts you want to Take</param>
        /// <param name="page">The denomination of posts you want to skip. (page - 1) * count </param>
        /// <returns>Collections of posts</returns>
        public IEnumerable<Post> GetAllByCategoryPaged(string category, int count, int page = 1)
        {
            return _context
                    .Posts
                    .Where(x => x.Published)
                    .Include(x => x.Excerpt)
                    .Include(x => x.Category)
                    .Include(x => x.PostTags)
                        .ThenInclude(i => i.Tag)
                    .Where(x => x.Category.Url.ToLower() == category)
                    .OrderByDescending(x => x.PostedOn)
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }

        public IEnumerable<Post> GetAllByCategoryName(string category, int? top)
        {
            var query = _context
                    .Posts
                    .Where(x => x.Published)
                    .Include(x => x.Excerpt)
                    .Include(x => x.Category)
                    .Where(x => x.Category.Name.ToLower() == category.ToLower())
                    .OrderByDescending(x => x.PostedOn);
            if (top != null)
                return query
                    .Take((int)top)
                    .ToList();
            else
                return query.ToList();
        }
        /// <summary>
        /// Get posts based on ids
        /// </summary>
        /// <param name="postIds">Collection of Ids</param>
        /// <returns>Collection of posts</returns>
        public IEnumerable<Post> GetPostsBasedOnIdCollection(List<int> postIds)
        {
            return _context
                    .Posts
                        .Where(t => postIds.Contains(t.PostId))
                    .Include(x => x.Category)
                    .Include(x => x.Excerpt)
                    .OrderBy(d => postIds.IndexOf(d.PostId)).ToList()
                    .ToList();
        }

        /// <summary>
        /// Get Previous iteration of post based on id
        /// </summary>
        /// <param name="id">Post Id</param>
        /// <returns>Post Entity</returns>
        public Post GetPreviousBasedOnId(int id)
        {
            return (from x in _context.Posts where x.PostId < id && x.Published orderby x.PostId descending select x).FirstOrDefault();
        }

        /// <summary>
        /// Get Next iteration of post based on id
        /// </summary>
        /// <param name="id">Post Id</param>
        /// <returns>Collection of Post Entities</returns>
        public Post GetNextBasedOnId(int id)
        {
            return (from x in _context.Posts where x.PostId > id && x.Published orderby x.PostId select x).FirstOrDefault();
        }

        /// <summary>
        /// Add new post
        /// </summary>
        /// <param name="post">Post model</param>
        /// <returns>New Post entity</returns>
        public void AddPost(Post post)
        {
            ////insert except
            //var except = new Excerpt()
            //{
            //    Content = post.Excerpt.Content
            //};
            //_context.Excerpts.Add(except);
            //_context.SaveChanges();
            //post.ExcerptId = except.ExcerptId;

            ////insert arcticel
            //var acticle = new Article()
            //{
            //    Content = post.Article.Content
            //};
            //_context.Articles.Add(acticle);
            //_context.SaveChanges();
            //post.ArticleId = acticle.ArticleId;

            //post.Excerpt = null;
            //post.Article = null;

            //post.CategoryId = post.Category.CategoryId;

            _context.Posts.Add(post);
            _context.SaveChanges();

        }

        /// <summary>
        /// Update post record
        /// </summary>
        /// <param name="post">Post model</param>
        public void Update(PostDto post)
        {
            var entity = _context
                .Posts
                .Include(x => x.Category)
                .Include(x => x.Excerpt)
                .FirstOrDefault(x => x.PostId == post.PostId);

            // Post
            entity.Url = post.Url;
            entity.Title = post.Title;
            entity.Description = post.Description;
            entity.IconImage = post.IconImage;
            entity.SmallImage = post.SmallImage;
            entity.Image = post.Image;
            entity.Link = post.Link;
            entity.ModifiedOn = DateTime.Now;
            entity.Meta = post.Meta;
            entity.Published = post.Published;

            // Excerpt
            entity.Excerpt.Content = post.Excerpt.Content;

            // Article
            entity.Article.Content = post.Article.Content;

            // Category :TODO: Cần check lại CategoryId tồn tại trong database, hiện tại api pass qua object id= 0
            if (post.Category != null && post.Category.CategoryId > 0)
                entity.CategoryId = post.Category.CategoryId;

            // Tags
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove post object
        /// </summary>
        /// <param name="url">Post URL</param>
        public void Remove(string url)
        {
            var entity = _context
                .Posts
                .FirstOrDefault(x => x.Url == url);

            _context.Posts.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAllPostForAdmin()
        {
            var posts = _context.Posts.Include(p => p.Category)
                                .Select(x => new
                                {
                                    x.PostId,
                                    x.Title,
                                    x.Category,
                                    x.Published
                                }).ToList();
            foreach (var p in posts)
            {
                var post = new Post();
                post.PostId = p.PostId;
                post.Title = p.Title;
                post.Category = p.Category;
                post.Published = p.Published;
                yield return post;
            }
        }

        public bool CheckTitle(string title)
        {
            if (_context.Posts.SingleOrDefault(p => p.Title == title) == null)
                return false;
            return true;
        }
    }
}
