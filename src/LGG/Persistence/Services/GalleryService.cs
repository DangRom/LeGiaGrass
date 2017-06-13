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
            return _galleryRepository.GetAll()
                    .Select(Mapper.Map<Gallery, GalleryDto>)
                    .OrderBy(x => x.Category.Name)
                    .ToList();
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
            return Mapper.Map<Gallery, GalleryDto>(_galleryRepository.GetById(id));
        }


        /// <summary>
        /// Create GalleryDto record
        /// If a Name is not provided, set Name and IMAGE to a GUID
        /// </summary>
        /// <param name="category">Category</param>
        public GalleryDto Add(GalleryDto gallery)
        {
            if (gallery.Name == null)
            {
                gallery.Name = Guid.NewGuid().ToString();
                gallery.Image = gallery.Name;
            }

            var response = _galleryRepository.Add(Mapper.Map<GalleryDto, Gallery>(gallery));
            gallery.GalleryId = response.GalleryId;
            return gallery;
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
    }
}
