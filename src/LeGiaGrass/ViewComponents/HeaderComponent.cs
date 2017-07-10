using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent{
         private readonly ICompanyRepository _headRepo;
         public HeaderViewComponent(ICompanyRepository headRepo) => _headRepo = headRepo;

         public async Task<IViewComponentResult> InvokeAsync(){
            try{
               var headmodel = await Task.Factory.StartNew(() => _headRepo.GetCompanyForHead());
               var head = new CompanyViewModel(){
                  Facebook = headmodel.Facebook,
                  Google = headmodel.Google,
                  Twitter = headmodel.Twitter,
                  Hotline = headmodel.Hotline
               };
               return View(head);
            }catch{throw;}
         }
    }
}