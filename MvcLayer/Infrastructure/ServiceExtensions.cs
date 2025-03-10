using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services;
using Repositories.Contract;

namespace MvcLayer.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection Services)
        {
            Services.AddScoped<IRepositoryManager, RepositoryManager>();
            Services.AddScoped<IAboutRepository, AboutRepository>();
            Services.AddScoped<IAuthorRepository,AuthorRepository>();
            Services.AddScoped<IBlogRepository,BlogRepository>();
            Services.AddScoped<ICategoryRepository,CategoryRepository>();
            Services.AddScoped<ICommentRepository,CommentRepository>();
            Services.AddScoped<IContactRepository,ContactRepository>();
            Services.AddScoped<ISubscribeMailRepository, SubscribeMailRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection Services)
        {
            Services.AddScoped<IServiceManager, ServiceManager>();
            Services.AddScoped<IAboutService, AboutManager>();
            Services.AddScoped<ICategoryService,CategoryManager>();
            Services.AddScoped<IBlogService, BlogManager>();
            Services.AddScoped<ISubscribeMailService, SubscribeMailManager>();
            Services.AddScoped<ICommentService, CommentManager>();

        }
    }
}
