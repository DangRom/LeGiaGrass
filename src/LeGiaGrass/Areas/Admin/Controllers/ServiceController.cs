using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Areas.Admin.Models;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.Areas.Admin.Controllers{

    [Area("Admin")]
    [Authorize]
    public class ServiceController : Controller{
        private readonly IServiceRepository _serviceRepo;
        public ServiceController(IServiceRepository serviceRepo) => _serviceRepo = serviceRepo;

        public async Task<IActionResult> Index(){
            try{
                var servicemodels = await Task.Factory.StartNew(() => _serviceRepo.GetAllService());
                var services = servicemodels.Select(c => new ServiceViewModel{
                    Id = c.Id,
                    Name = c.Name,
                    Activated = c.Activated,
                    Status = c.Status
                }).ToList();
                return View(services);
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public IActionResult New(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(ServiceViewModel service){
            try{
                if(ModelState.IsValid){
                    if(!_serviceRepo.CheckAlias(service.Alias)){
                        var servicemodel = new ServiceModel{
                            Name = service.Name,
                            Alias = service.Alias,
                            Image = service.Image,
                            Status = "",
                            ShortDescription = service.ShortDescription,
                            Content = service.Content,
                            Activated = service.Activated,
                            Price = service.Price
                        };
                        await Task.Factory.StartNew(() => _serviceRepo.Insert(servicemodel));
                        return RedirectToAction("New");
                    }
                    ModelState.AddModelError("", "hãy thử tên khác hoặc kiểm tra lại định danh");
                }
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Update(int id){
            try{
                var servicemodel = await Task.Factory.StartNew(() => _serviceRepo.GetServiceById(id));
                if(servicemodel == null){
                    ModelState.AddModelError("", "không tìm thấy dữ liệu");
                    return View();
                }
                var service = new ServiceViewModel(){
                    Id = servicemodel.Id,
                    Name = servicemodel.Name,
                    Alias = servicemodel.Alias,
                    Image = servicemodel.Image,
                    Status = "",
                    ShortDescription = servicemodel.ShortDescription,
                    Content = servicemodel.Content,
                    Activated = servicemodel.Activated,
                    Price = servicemodel.Price
                };
                return View(service);
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServiceViewModel service){
            try{
                if(ModelState.IsValid){
                    var servicemodel = new ServiceModel(){
                        Id = service.Id,
                        Name = service.Name,
                        Alias = service.Alias,
                        Image = service.Image,
                        Status = "",
                        ShortDescription = service.ShortDescription,
                        Content = service.Content,
                        Activated = service.Activated,
                        Price = service.Price   
                    };
                    await Task.Factory.StartNew(() => _serviceRepo.Update(servicemodel));
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
                _serviceRepo.Delete(id);
                return Json("OK");
            }catch(Exception ex){
                return Json(ex.Message);
            }
        }
    }
}