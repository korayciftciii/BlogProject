using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
        Task<IQueryable<Blog>> GetAllBlogAsync(bool trackChanges);
        Task<Blog> GetBlogByIdAsync(int blogId, bool trackChanges);
        void CreateOneBlog(Blog blog);
        void UpdateOneBlog(Blog blog);
        void DeleteOneBlog(Blog blog);
    }
}
