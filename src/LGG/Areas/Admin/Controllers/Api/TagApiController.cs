﻿#if (DEBUG)
using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LGG.Areas.Admin.Controllers.Api
{
    [Authorize]
    [Route("api/tags")]
    public class TagApiController : Controller
    {
        private readonly ITagService _tagService;

        public TagApiController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IEnumerable<TagDto> GetAll(int? count, int? page)
        {
            if (count == null || page == null)
            {
                return _tagService.GetAll();
            }

            return _tagService.GetAllPaged((int)count, (int)page);
        }

        [HttpGet("{id}", Name = "GetTag")]
        public IActionResult GetById(int id)
        {
            var item = _tagService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Create([FromBody]TagDto tag)
        {
            if (tag == null)
            {
                return BadRequest();
            }

            _tagService.Add(tag);
            return CreatedAtRoute("GetTag", new { id = tag.TagId }, tag);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Update(int id, [FromBody] TagDto item)
        {
            if (item == null || item.TagId != id)
            {
                return BadRequest();
            }

            var todo = _tagService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _tagService.Update(item);
            return new NoContentResult();
        }

        //[HttpDelete("{id}")]
        //[Authorize(Policy = "isSuperUser")]
        //public IActionResult Delete(int id)
        //{
        //    var todo = _tagService.GetById(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _tagService.Remove(id);
        //    return new NoContentResult();
        //}
    }
}
#endif