using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<CompanyDto> GetAll(int? count, int? page,
            bool includeAbout = true,
            bool includePrivacy = true,
            bool includeTermsOfUse = true)
        {
            if (count == null || page == null)
            {
                return _companyService.GetAll(includeAbout, includePrivacy, includeTermsOfUse);
            }

            return _companyService.GetAllPaged((int)count, (int)page);
        }

        [HttpGet("{id}", Name = "GetCompany")]
        public IActionResult GetById(int id)
        {
            var item = _companyService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Create([FromBody]CompanyDto company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            var first = _companyService.GetCompanyFirstOrDefault(true, true, true);

            if (first != null)
                return CreatedAtRoute("GetCompany", new { id = first.Id }, first);

            _companyService.Add(company);
            return CreatedAtRoute("GetCompany", new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "isSuperUser")]
        public IActionResult Update(int id, [FromBody] CompanyDto item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _companyService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _companyService.Update(item);
            return new NoContentResult();
        }

        //[HttpDelete("{id}")]
        //[Authorize(Policy = "isSuperUser")]
        //public IActionResult Delete(int id)
        //{
        //    var todo = _companyService.GetById(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _companyService.Remove(id);
        //    return new NoContentResult();
        //}
    }
}
