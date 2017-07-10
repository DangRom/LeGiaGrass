using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Areas.Admin.Models;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeGiaGrass.Areas.Admin.Controllers{
    [Area("Admin")]
    [Authorize]
    public class FeedbackController : Controller{
        private readonly IServiceRepository _serviceRepo;
        private readonly IFeedbackRepository _feedbackRepo;
        private List<SelectListItem> GetServices(){
            var servicemodels = _serviceRepo.GetAllServiceForFeedback();
            var service = servicemodels.Select(s => new SelectListItem{
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            service.Insert(0, new SelectListItem{Value = "", Text = "--chon khoa hoc--"});
            return service;
        }

        public FeedbackController(IServiceRepository serviceRepo, IFeedbackRepository feedbackRepo){
            _serviceRepo = serviceRepo;
            _feedbackRepo = feedbackRepo;
        }

        public async Task<IActionResult> Index(){
            try{
                var feedmodels = await Task.Factory.StartNew(() => _feedbackRepo.GetAllFeedbank());
                var feeds = feedmodels.Select(f => new FeedbackViewModel{
                    Id = f.Id,
                    FullName = f.FullName,
                    ServiceName = f.ServiceName
                }).ToList();
                return View(feeds);
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> New(){
            try{
                ViewBag.ListService = await Task.Factory.StartNew(() => GetServices());
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> New(FeedbackViewModel feed){
            ViewBag.ListService = await Task.Factory.StartNew(() => GetServices());
            try{
                if(ModelState.IsValid){
                    var feedmodel = new FeedbackModel(){
                        FullName = feed.FullName,
                        Avatar = feed.Avatar,
                        Content = feed.Content,
                        CreateDate = DateTime.Now,
                        ServiceId = feed.ServiceId
                    };
                    _feedbackRepo.Insert(feedmodel);
                    return RedirectToAction("New");
                }
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Update(int id){
            try{
                ViewBag.ListService = await Task.Factory.StartNew(() => GetServices());
                var feedmodel = _feedbackRepo.GetFeedbackById(id);
                if(feedmodel == null){
                    ModelState.AddModelError("","không tìm thấy dữ liệu");
                    return View();
                }
                var feed = new FeedbackViewModel(){
                    Id = feedmodel.Id,
                    FullName = feedmodel.FullName,
                    Avatar = feedmodel.Avatar,
                    ServiceId = feedmodel.ServiceId,
                    Content = feedmodel.Content
                };
                return View(feed);
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }         
        }

        [HttpPost]
        public async Task<IActionResult> Update(FeedbackViewModel feed){
            try{
                if(ModelState.IsValid){
                    var feedmodel = new FeedbackModel(){
                        Id = feed.Id,
                        FullName = feed.FullName,
                        Avatar = feed.Avatar,
                        ServiceId = feed.ServiceId,
                        Content = feed.Content
                    };
                    await Task.Factory.StartNew(() => _feedbackRepo.Update(feedmodel));
                    return RedirectToAction("Index");
                }
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpDelete]
        public JsonResult Delete(int id){
            try{
                _feedbackRepo.Delete(id);
                return Json("OK");
            }catch(Exception ex){
                return Json(ex.Message);
            }
        }
    }
}