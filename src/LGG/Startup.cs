using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using LGG.Persistence;
using LGG.Persistence.Repositories;
using LGG.Persistence.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using MySQL.Data.Entity.Extensions;
using Pioneer.Pagination;
using System;
using System.Text;
using System.Threading.Tasks;

namespace LGG
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddSingleton(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("MySqlConnection"),
                    b => b.MigrationsAssembly("LGG")
                )
            );

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            ConfigureServicesIdentity(services);

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("isSuperUser", p => p.RequireClaim("isSuperUser", "true"));
            });

            // Change default Login path
            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new PathString("/admin/account/login");
            });

            services.AddMvc();

            // Add application services.
            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
            services.Configure<CompanyDto>(Configuration.GetSection("Company"));

            services.AddTransient<IPaginatedMetaService, PaginatedMetaService>();
            services.AddTransient<IdentitySetup>();

            // Repositories
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostTagRepository, PostTagRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();
            // Services
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostTagService, PostTagService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<ICommunicationService, CommunicationService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ISiteMapService, SiteMapService>();
            services.AddTransient<IGalleryService, GalleryService>();

            services.AddTransient<ApplicationEnvironment>();
            services.AddTransient<HostingEnvironment>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IdentitySetup identitySetup)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }


            MapperConfig.Config();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {

                app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
                identitySetup.Setup().Wait();
                //defaultData.InitializeCompanyDataAsync(app.ApplicationServices).Wait();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        MaxAge = TimeSpan.FromSeconds(31536000)
                    };
                }
            });

            ConfigureSecurity(app);
            ConfigureMvc(app);

        }

        private static void ConfigureServicesIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(config =>
            {
                config.Cookies.ApplicationCookie.Events =
                    new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = ctx =>
                        {
                            // If we were redirect to login from api..
                            if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                            {
                                ctx.Response.StatusCode = 401;
                                return Task.FromResult<object>(null);
                            }

                            ctx.Response.Redirect(ctx.RedirectUri);
                            return Task.FromResult<object>(null);
                        },
                        OnRedirectToAccessDenied = ctx =>
                        {
                            // If access is denied from api...
                            if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                            {
                                ctx.Response.StatusCode = 403;
                                return Task.FromResult<object>(null);
                            }

                            ctx.Response.Redirect(ctx.RedirectUri);
                            return Task.FromResult<object>(null);
                        }
                    };
            });
        }

        private void ConfigureSecurity(IApplicationBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppConfiguration:Key").Value)),
                    ValidAudience = Configuration.GetSection("AppConfiguration:SiteUrl").Value,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration.GetSection("AppConfiguration:SiteUrl").Value
                }
            });

            app.UseIdentity();
        }

        private static void ConfigureMvc(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                // Areas support
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Post",
                    template: "post/{id}",
                    defaults: new { controller = "Post", action = "Index" });

                routes.MapRoute(
                    name: "BlogPost",
                    template: "post",
                    defaults: new { controller = "blog", action = "Index" });

                routes.MapRoute(
                    name: "BlogTag",
                    template: "tag",
                    defaults: new { controller = "blog", action = "Index" });

                routes.MapRoute(
                    name: "BlogCategory",
                    template: "category",
                    defaults: new { controller = "blog", action = "Index" });

                routes.MapRoute(
                    name: "Category",
                    template: "category/{id}/{page?}",
                    defaults: new { controller = "blog", action = "Category" });

                routes.MapRoute(
                    name: "Tag",
                    template: "tag/{id}/{page?}",
                    defaults: new { controller = "blog", action = "Tag" });

                routes.MapRoute(
                    name: "Blog",
                    template: "blog/{page?}",
                    defaults: new { controller = "blog", action = "Index" });

                routes.MapRoute(
                    name: "SiteMap",
                    template: "sitemap.xml",
                    defaults: new { controller = "home", action = "SiteMap" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "About",
                   template: "about/{page?}",
                   defaults: new { controller = "about", action = "Index" });

            });
        }
    }
}
