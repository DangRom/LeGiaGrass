using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LGG.Areas.Admin.Controllers.Api
{
    [Authorize]
    [Route("api/categories")]
    public class CategoryApiController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryApiController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> GetAll(int? count, int? page)
        {
            if (count == null || page == null)
            {
                return _categoryService.GetAll();
            }

            return _categoryService.GetAllPaged((int)count, (int)page);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetById(int id)
        {
            var item = _categoryService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Create([FromBody]CategoryDto tag)
        {
            if (tag == null)
            {
                return BadRequest();
            }

            _categoryService.Add(tag);
            return CreatedAtRoute("GetCategory", new { id = tag.CategoryId }, tag);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Update(int id, [FromBody] CategoryDto item)
        {
            if (item == null || item.CategoryId != id)
            {
                return BadRequest();
            }

            var todo = _categoryService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _categoryService.Update(item);
            return new NoContentResult();
        }

        //[HttpDelete("{id}")]
        //[Authorize(Policy = "isSuperUser")]
        //public IActionResult Delete(int id)
        //{
        //    var todo = _categoryService.GetById(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _categoryService.Remove(id);
        //    return new NoContentResult();
        //}
    }
}
