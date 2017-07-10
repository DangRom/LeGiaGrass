using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "SlideHome")]
    public class SlideHomeViewComponent : ViewComponent
    {
        private readonly ISlideRepository _slideRepo;
        public SlideHomeViewComponent(ISlideRepository slideRepo) => _slideRepo = slideRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var slidemodels = await Task.Factory.StartNew(() => _slideRepo.GetAllSlideForHome());
                var slides = slidemodels.Select(s => new SlideViewModel
                {
                    Name = s.Name,
                    Alias = s.Alias,
                    Image = s.Image,
                    ButtonViewer = s.ButtonViewer,
                    LinkViewer = s.LinkViewer
                }).ToList();
                return View(slides);
            }
            catch { throw; }
        }
    }
}