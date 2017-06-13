using LGG.Core.Models;
using LGG.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LGG.Persistence.Repositories
{
    public class PostTagRepository : IPostTagRepository
    {
        private readonly ApplicationDbContext _context;

        public PostTagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new PostTag record
        /// </summary>
        /// <param name="postTag">Compound Key</param>
        /// <returns>Qualified PostTag</returns>
        public PostTag Add(PostTag postTag)
        {
            _context
                .PostTags
                .Add(postTag);

            _context.SaveChanges();

            return postTag;
        }

        /// <summary>
        /// Delete a PostTagEntity by compound key
        /// </summary>
        /// <param name="postTag">Compound Key</param>
        public void RemoveByCompound(PostTag postTag)
        {
            var entity = _context
               .PostTags
               .FirstOrDefault(x => x.PostId == postTag.PostId && x.TagId == postTag.TagId);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified; //@bravohex: Handled FAST Click by jQuery
                _context.PostTags.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
