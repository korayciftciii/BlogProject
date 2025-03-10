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
        private readonly IAboutRepository _aboutRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ISubscribeMailRepository _subscribeMailRepository;

        public RepositoryManager(RepositoryContext repositoryContext,
            IAboutRepository aboutRepository,
            IAuthorRepository authorRepository,
            IBlogRepository blogRepository,
            ICategoryRepository categoryRepository,
            ICommentRepository commentRepository,
            IContactRepository contactRepository,
            ISubscribeMailRepository subscribeMailRepository)
        {
            _repositoryContext = repositoryContext;
            _aboutRepository = aboutRepository;
            _authorRepository = authorRepository;
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
            _contactRepository = contactRepository;
            _subscribeMailRepository = subscribeMailRepository;
        }

        public IAboutRepository About => _aboutRepository;
        public IAuthorRepository Author => _authorRepository;
        public ICategoryRepository Category => _categoryRepository;
        public IContactRepository Contact => _contactRepository;
        public IBlogRepository Blog => _blogRepository;
        public ICommentRepository Comment => _commentRepository;
        public ISubscribeMailRepository SubscribeMail => _subscribeMailRepository;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
