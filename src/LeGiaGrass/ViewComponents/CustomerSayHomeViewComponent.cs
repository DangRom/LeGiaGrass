using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "CustomerSayHome")]
    public class CustomerSayHomeViewComponent : ViewComponent
    {
        private readonly IFeedbackRepository _feedRepo;
        public CustomerSayHomeViewComponent(IFeedbackRepository feedRepo) => _feedRepo = feedRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var feedmodels = await Task.Factory.StartNew(() => _feedRepo.GetAllFeedbackForHomePage());
                var feeds = feedmodels.Select(f => new FeedbackViewModel
                {
                    FullName = f.FullName,
                    Avatar = f.Avatar,
                    Content = f.Content
                }).ToList();
                return View(feeds);
            }
            catch { throw; }
        }
    }
}