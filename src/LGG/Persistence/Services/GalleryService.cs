using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IGalleryRepository _galleryRepository;

        public GalleryService(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        /// <summary>
        /// Get all Galleries
        /// </summary>
        /// <returns>Collection of Galleries</returns>
        public IEnumerable<GalleryDto> GetAll()
        {
            //return _galleryRepository.GetAll().Select(g => new GalleryDto
            //{
            //    GalleryId = g.GalleryId,
            //    Image = g.Image,
            //    Name = g.Name,
            //    Description=g.Description,
            //    CategoryName = g.Category.Name
            //}).ToList();

            return Mapper.Map<IList<Gallery>, IList<GalleryDto>>(_galleryRepository.GetAll().ToList());
        }

        /// <summary>
        /// Get paged collection of Gallery
        /// </summary>
        /// <param name="count">Number of Galleries in page</param>
        /// <param name="page">Page of Galleries</param>
        /// <returns>Count of Galleries starting at page</returns>
        public IEnumerable<GalleryDto> GetAllPaged(int count, int page)
        {
            return _galleryRepository
                    .GetAllPaged(count, page).Select(Mapper.Map<Gallery, GalleryDto>);
        }

        /// <summary>
        /// Get GalleryDto by id
        /// </summary>
        /// <param name="id">GalleryDto id</param>
        /// <returns>Category Object</returns>
        public GalleryDto GetById(int id)
        {
            var gallerymodel = _galleryRepository.GetById(id);
            var gallery = new GalleryDto()
            {
                GalleryId = gallerymodel.GalleryId,
                Description = gallerymodel.Description,
                Name = gallerymodel.Name,
                Image = gallerymodel.Image,
                CategoryId = gallerymodel.Category.CategoryId
            };
            return gallery;
        }


        /// <summary>
        /// Create GalleryDto record
        /// If a Name is not provided, set Name and IMAGE to a GUID
        /// </summary>
        /// <param name="category">Category</param>
        public void Add(GalleryDto gallery)
        {
            var gall = new Gallery()
            {
                GalleryId = gallery.GalleryId,
                Name = gallery.Name,
                Image = gallery.Image,
                CategoryId = gallery.CategoryId,
            };
            _galleryRepository.Add(gall);
        }

        /// <summary>
        /// Update GalleryDto record
        /// </summary>
        /// <param name="Gallery">Updated Gallery</param>
        public void Update(GalleryDto gallery)
        {
            _galleryRepository.Update(gallery);
        }

        /// <summary>
        /// Delete Gallery record based on id
        /// </summary>
        /// <param name="id">Gallery Id</param>
        public void Remove(int id)
        {
            _galleryRepository.Remove(id);
        }

        public bool CheckName(string name)
        {
            return _galleryRepository.CheckName(name);
        }

        public IEnumerable<GalleryDto> GetByCategoryName(string categoryName)
        {
            return Mapper.Map<IList<Gallery>, IList<GalleryDto>>(_galleryRepository.GetByCategoryName(categoryName).ToList());
        }
    }
}
