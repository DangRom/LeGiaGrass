using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Collection of Categories</returns>
        public IEnumerable<CategoryDto> GetAll()
        {
            return _categoryRepository.GetAll()
                    .Select(Mapper.Map<Category, CategoryDto>)
                    .OrderBy(x => x.Name)
                    .ToList();
        }

        /// <summary>
        /// Get paged collection of category
        /// </summary>
        /// <param name="count">Number of categories in page</param>
        /// <param name="page">Page of categories</param>
        /// <returns>Count of categories starting at page</returns>
        public IEnumerable<CategoryDto> GetAllPaged(int count, int page)
        {
            return _categoryRepository
                    .GetAllPaged(count, page).Select(Mapper.Map<Category, CategoryDto>);
        }

        /// <summary>
        /// Get CategoryDto by id
        /// </summary>
        /// <param name="id">CategoryDto id</param>
        /// <returns>Category Object</returns>
        public CategoryDto GetById(int id)
        {
            return Mapper.Map<Category, CategoryDto>(_categoryRepository.GetById(id));
        }


        /// <summary>
        /// Create CategoryDto record
        /// If a Name is not provided, set Name and URL to a GUID
        /// </summary>
        /// <param name="category">Category</param>
        public CategoryDto Add(CategoryDto category)
        {
            if (category.Name == null)
            {
                category.Name = Guid.NewGuid().ToString();
                category.Url = category.Name;
            }

            var response = _categoryRepository.Add(Mapper.Map<CategoryDto, Category>(category));
            category.CategoryId = response.CategoryId;
            return category;
        }

        /// <summary>
        /// Update CategoryDto record
        /// </summary>
        /// <param name="category">Updated Category</param>
        public void Update(CategoryDto category)
        {
            _categoryRepository.Update(category);
        }

        /// <summary>
        /// Delete Category record based on id
        /// </summary>
        /// <param name="id">Category Id</param>
        public void Remove(int id)
        {
            _categoryRepository.Remove(id);
        }

        public bool CheckName(string catename)
        {
            return _categoryRepository.CheckName(catename);
        }
    }
}
