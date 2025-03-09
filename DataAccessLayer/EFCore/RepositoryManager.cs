using Repositories.Contract;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IAboutRepository> _aboutRepository;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBlogRepository> _blogRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;
        private readonly Lazy<IContactRepository> _contactRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _aboutRepository = new Lazy<IAboutRepository>(()=>new AboutRepository(_repositoryContext));//LAZY LOADING
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_repositoryContext));//LAZY LOADING
            _blogRepository = new Lazy<IBlogRepository>(() => new BlogRepository(_repositoryContext));//LAZY LOADING
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_repositoryContext));//LAZY LOADING
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(_repositoryContext));//LAZY LOADING
            _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(_repositoryContext));//LAZY LOADING
        }

        

        public IAboutRepository About => _aboutRepository.Value;
        public IAuthorRepository Author => _authorRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public IContactRepository Contact => _contactRepository.Value;

        public IBlogRepository Blog => _blogRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
