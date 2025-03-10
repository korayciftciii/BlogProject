using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAboutService> _aboutService;
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IBlogService> _blogService;
        private readonly Lazy<ISubscribeMailService> _subscribeMailService;
        public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _aboutService = new Lazy<IAboutService>(() => new AboutManager(repositoryManager));
            //_authorService = new Lazy<IAuthorService>(()=>new AuthManager(repositoryManager,mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager, mapper));
            _blogService = new Lazy<IBlogService>(() => new BlogManager(repositoryManager, mapper));
            _subscribeMailService = new Lazy<ISubscribeMailService>(() => new SubscribeMailManager(repositoryManager, mapper));
        }

        public IAboutService AboutService => _aboutService.Value;
        public IAuthorService AuthorService => _authorService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IBlogService BlogService => _blogService.Value;
        public ISubscribeMailService SubscribeMailService=>_subscribeMailService.Value;

    }
}
