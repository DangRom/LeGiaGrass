using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly ApplicationDbContext _context;

        public GalleryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Galleries
        /// </summary>
        /// <returns>Gallery Collection</returns>
        public IEnumerable<Gallery> GetAll()
        {
            return _context
                      .Galleries
                      .Include(x => x.Category)
                      .ToList();
        }

        /// <summary>
        /// Get Gallery By Id
        /// </summary>
        /// <param name="id">Gallery Id</param>
        /// <returns>Gallery Entity</returns>
        public Gallery GetById(int id)
        {
            return _context
                    .Galleries
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.GalleryId == id);
        }

        /// <summary>
        /// Create Gallery
        /// </summary>
        /// <param name="GalleryEntity">Gallery Entity to save</param>
        /// <returns>Gallery Entity with Id</returns>
        public void Add(Gallery galleryEntity)
        {
            _context
                .Galleries
                .Add(galleryEntity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update Entity based on Model
        /// </summary>
        /// <param name="Gallery">Gallery Object</param>
        public void Update(GalleryDto gallery)
        {
            var entity = _context
                .Galleries
                .FirstOrDefault(x => x.GalleryId == gallery.GalleryId);

            entity.Description = gallery.Description;
            entity.Image = gallery.Image;
            entity.Name = gallery.Name;
            entity.CategoryId = gallery.CategoryId;

            // _context.Galleries.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove Gallery record based on Id
        /// </summary>
        /// <param name="id">Gallery Id</param>
        public void Remove(int id)
        {
            var entity = _context
                .Galleries
                .FirstOrDefault(x => x.GalleryId == id);

            _context.Galleries.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get a collection of Galleries by skipping x and taking y
        /// </summary>
        /// <param name="count">The total number of Galleries you want to Take</param>
        /// <param name="page">The denomination of Galleries you want to skip. (page - 1) * count </param>
        /// <returns>Collections of Galleries</returns>
        public IEnumerable<Gallery> GetAllPaged(int count, int page)
        {
            return _context
                    .Galleries
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }

        public bool CheckName(string name)
        {
            if (_context.Galleries.FirstOrDefault(g => g.Name == name) == null) return false;
            return true;
        }

        public IEnumerable<Gallery> GetByCategoryName(string categoryName)
        {
            return _context
                   .Galleries
                   .Where(x => x.Category.Name.ToLower() == categoryName.ToLower())
                   .ToList();
        }
    }
}
