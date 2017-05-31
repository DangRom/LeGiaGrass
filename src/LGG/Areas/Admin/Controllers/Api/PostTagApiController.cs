using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers.Api
{
    [Authorize]
    [Route("api/post-tags")]
    public class PostTagApiController : Controller
    {
        private readonly IPostTagService _postTagService;

        public PostTagApiController(IPostTagService postTagService)
        {
            _postTagService = postTagService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]PostTagDto postTag)
        {
            var newPostTage = _postTagService.Add(postTag);
            return CreatedAtRoute("GetPost", new { url = newPostTage.PostTagId }, newPostTage);
        }

        [HttpPost]
        [Route("remove/compound")]
        public IActionResult DeletePostTag([FromBody]PostTagDto postTag)
        {
            _postTagService.Delete(postTag);
            return new NoContentResult();
        }
    }
}
