using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "OurGalleryHome")]
    public class OurGalleryHomeViewComponent : ViewComponent
    {
        private readonly IImageRepository _galleryRepo;

        public OurGalleryHomeViewComponent(IImageRepository galleryRepo) => _galleryRepo = galleryRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var gallerymodels = await Task.Factory.StartNew(() => _galleryRepo.GetAllImageForHomePage());
                var gallerys = gallerymodels.Select(g => new GalleryHomeViewModel
                {
                    Name = g.Name,
                    Image = g.Image
                }).ToList();
                ViewBag.Portfolios = gallerys.GroupBy(p => p.Name).Select(v => v.First()).ToList();
                return View(gallerys);
            }
            catch { throw; }
        }
    }
}