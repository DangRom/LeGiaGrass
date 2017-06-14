using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LGG.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Category Collection</returns>
        public IEnumerable<Category> GetAll()
        {
            return _context
                      .Categories
                      .ToList();
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Category Entity</returns>
        public Category GetById(int id)
        {
            return _context
                    .Categories
                    .FirstOrDefault(x => x.CategoryId == id);
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="categoryEntity">Category Entity to save</param>
        /// <returns>Category Entity with Id</returns>
        public Category Add(Category categoryEntity)
        {
            _context
                .Categories
                .Add(categoryEntity);
            _context.SaveChanges();

            return categoryEntity;
        }

        /// <summary>
        /// Update Entity based on Model
        /// </summary>
        /// <param name="category">Category Object</param>
        public void Update(CategoryDto category)
        {
            var entity = _context
                .Categories
                .FirstOrDefault(x => x.CategoryId == category.CategoryId);

            entity.Url = category.Url;
            entity.Name = category.Name;

            _context.SaveChanges();
        }

        /// <summary>
        /// Remove Category record based on Id
        /// </summary>
        /// <param name="id">Category Id</param>
        public void Remove(int id)
        {
            var entity = _context
                .Categories
                .FirstOrDefault(x => x.CategoryId == id);

            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get a collection of categories by skipping x and taking y
        /// </summary>
        /// <param name="count">The total number of categories you want to Take</param>
        /// <param name="page">The denomination of categories you want to skip. (page - 1) * count </param>
        /// <returns>Collections of Categories</returns>
        public IEnumerable<Category> GetAllPaged(int count, int page)
        {
            return _context
                    .Categories
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }

        public bool CheckName(string catename)
        {
            if (_context.Categories.FirstOrDefault(c => c.Name == catename) == null)
            {
                return false;
            }
            return true;
        }
    }
}
