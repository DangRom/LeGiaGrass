using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var tes = await Task.Factory.StartNew(() => _testimonialService.GetAll());
                return View(tes);
            }
            catch { return View("Error"); }
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(TestimonialDto tes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Task.Factory.StartNew(() => _testimonialService.Add(tes));
                    return RedirectToAction(nameof(TestimonialController.Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                if (id > 0)
                {
                    var tes = await Task.Factory.StartNew(() => _testimonialService.GetById(id));
                    return View(tes);
                }

                ModelState.AddModelError("", "Nội dung này không tồn tại");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(TestimonialDto tes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Task.Factory.StartNew(() => _testimonialService.Update(tes));
                    return RedirectToAction(nameof(TestimonialController.Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await Task.Factory.StartNew(() => _testimonialService.Remove(id));
                return Json("OK");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
