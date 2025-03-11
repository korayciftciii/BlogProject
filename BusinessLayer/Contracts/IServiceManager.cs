using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAboutService AboutService { get; }
        IAuthorService AuthorService { get; }
        ICategoryService CategoryService { get; }
        IBlogService BlogService { get; }   
        ISubscribeMailService SubscribeMailService { get; }
        ICommentService CommentService { get; }
        IContactService ContactService { get; }
        
    }
}
