#if (DEBUG)
using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers.Api
{
    [Authorize]
    [Route("api/companies")]
    public class CompanyApiController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyApiController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var item = _companyService.GetCompanyFirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPut]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Update([FromBody] CompanyDto item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var todo = _companyService.GetCompanyFirstOrDefault();
            if (todo == null)
            {
                return NotFound();
            }

            _companyService.Update(item);
            return new NoContentResult();
        }
    }
}
#endif