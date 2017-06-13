using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LGG.Areas.Admin.Controllers.Api
{
    [Authorize]
    [Route("api/galleries")]
    public class GalleryApiController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryApiController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpGet]
        public IEnumerable<GalleryDto> GetAll(int? count, int? page)
        {
            if (count == null || page == null)
            {
                return _galleryService.GetAll();
            }

            return _galleryService.GetAllPaged((int)count, (int)page);
        }

        [HttpGet("{id}", Name = "GetGallery")]
        public IActionResult GetById(int id)
        {
            var item = _galleryService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Create([FromBody]GalleryDto gallery)
        {
            if (gallery == null)
            {
                return BadRequest();
            }

            _galleryService.Add(gallery);
            return CreatedAtRoute("GetGallery", new { id = gallery.GalleryId }, gallery);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Update(int id, [FromBody] GalleryDto item)
        {
            if (item == null || item.GalleryId != id)
            {
                return BadRequest();
            }

            var todo = _galleryService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _galleryService.Update(item);
            return new NoContentResult();
        }

        //[HttpDelete("{id}")]
        //[Authorize(Policy = "isSuperUser")]
        //public IActionResult Delete(int id)
        //{
        //    var todo = _galleryService.GetById(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _galleryService.Remove(id);
        //    return new NoContentResult();
        //}
    }
}