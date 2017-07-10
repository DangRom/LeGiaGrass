using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "Footer")]
    public class FooterViewComponent : ViewComponent{
       private readonly ICompanyRepository _companyRepo;
       private readonly IPostRepository _postRepo;
       private readonly IServiceRepository _serviceRepo;

       public FooterViewComponent(ICompanyRepository companyRepo, IPostRepository postRepo,
         IServiceRepository serviceRepo){
            _companyRepo = companyRepo;
            _postRepo = postRepo;
            _serviceRepo = serviceRepo;
         }

      public async Task<IViewComponentResult> InvokeAsync(){
         try{
            var postmodels = await Task.Factory.StartNew(() => _postRepo.GetForFooter());
            var posts = postmodels.Select(p => new MenuLineViewModel{
               Name = p.Name,
               Alias = p.Alias
            }).ToList();

            var companymodel = await Task.Factory.StartNew(() => _companyRepo.GetCompanyForFooter());
            var company = new CompanyViewModel(){
               Address = companymodel.Address,
               Email = companymodel.Email,
               TaxCode = companymodel.TaxCode,
               Phone = companymodel.Phone,
               Hotline = companymodel.Hotline,
               Facebook = companymodel.Facebook,
               Google = companymodel.Google,
               Tweeter = companymodel.Tweeter
            };

            var servicemodels = await Task.Factory.StartNew(() => _serviceRepo.GetForFooter());
            var services = servicemodels.Select(c => new MenuLineViewModel{
               Name = c.Name,
               Alias = c.Alias
            }).ToList();

            var footer = new FooterViewModel(){
               Company = company,
               LastPost = posts,
               Service = services
            };
            return View(footer);
         }catch{throw;}
      }
    }
}