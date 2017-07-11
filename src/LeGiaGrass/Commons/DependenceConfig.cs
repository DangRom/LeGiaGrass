using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Repository;
using Microsoft.Extensions.DependencyInjection;
using LeGiaGrass.Services.IServices;
using LeGiaGrass.Services.Services;

namespace LeGiaGrass.Commons{
    public static class DependenceConfig{
        public static void InitDependence(IServiceCollection service){
            service.AddSingleton<ICategoryRepository, CategoryRepository>();
            service.AddSingleton<ICompanyRepository, CompanyRepository>();
            service.AddSingleton<IServiceRepository, ServiceRepository>();
            service.AddSingleton<IFeedbackRepository, FeedbackRepository>();
            service.AddSingleton<ISlideRepository, SlideRepository>();
            service.AddSingleton<IPostRepository, PostRepository>();
            service.AddSingleton<IUserRepository, UserRepository>();
            service.AddSingleton<IImageRepository, ImageRepository>();
            service.AddSingleton<ICommunicationService, CommunicationService>();
        }
    }
}