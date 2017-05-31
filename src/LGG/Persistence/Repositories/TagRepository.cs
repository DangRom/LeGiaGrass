using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Tags
        /// </summary>
        /// <returns>Tag Collection</returns>
        public IEnumerable<Tag> GetAll()
        {
            return _context
                      .Tags
                      .ToList();
        }

        /// <summary>
        /// Get Tag By Id
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <returns>Tag Entity</returns>
        public Tag GetById(int id)
        {
            return _context
                    .Tags
                    .FirstOrDefault(x => x.TagId == id);
        }

        /// <summary>
        /// Create Tag
        /// </summary>
        /// <param name="tagEntity">Tag Entity to save</param>
        /// <returns>Tag Entity with Id</returns>
        public Tag Add(Tag tagEntity)
        {
            _context
                .Tags
                .Add(tagEntity);
            _context.SaveChanges();

            return tagEntity;
        }

        /// <summary>
        /// Update Entity based on Model
        /// </summary>
        /// <param name="tag">Tag Object</param>
        public void Update(TagDto tag)
        {
            var entity = _context
                .Tags
                .FirstOrDefault(x => x.TagId == tag.TagId);

            entity.Url = tag.Url;
            entity.Name = tag.Name;

            _context.SaveChanges();
        }

        /// <summary>
        /// Remove Tag record based on Id
        /// </summary>
        /// <param name="id">Tag Id</param>
        public void Remove(int id)
        {
            var entity = _context
                .Tags
                .FirstOrDefault(x => x.TagId == id);

            _context.Tags.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get a collection of tags by skipping x and taking y
        /// </summary>
        /// <param name="count">The total number of tags you want to Take</param>
        /// <param name="page">The denomination of tags you want to skip. (page - 1) * count </param>
        /// <returns>Collections of Tags</returns>
        public IEnumerable<Tag> GetAllPaged(int count, int page)
        {
            return _context
                    .Tags
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }
    }
}
