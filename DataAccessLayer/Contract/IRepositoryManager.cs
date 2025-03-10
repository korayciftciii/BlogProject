using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IAboutRepository About { get; }
        ICategoryRepository Category { get; }
        IContactRepository Contact { get; }
        IBlogRepository Blog { get; }
        ICommentRepository Comment { get; }
        IAuthorRepository Author { get; }
        ISubscribeMailRepository SubscribeMail { get; }

        Task SaveAsync();
    }
}
