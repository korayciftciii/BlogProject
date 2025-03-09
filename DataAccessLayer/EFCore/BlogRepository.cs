using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public  class BlogRepository :RepositoryBase<Blog> ,IBlogRepository
    {
    
        public BlogRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOneBlog(Blog blog) => Create(blog);
    
        public void DeleteOneBlog(Blog blog)=>Delete(blog);
        

        public async Task<IQueryable<Blog>> GetAllBlogAsync(bool trackChanges)=> await Task.FromResult(FindAll(trackChanges));

        public async Task<Blog> GetBlogByIdAsync(int blogId, bool trackChanges) => await FindByCondition(a=>a.BlogId.Equals(blogId),trackChanges).SingleOrDefaultAsync();
        
        public void UpdateOneBlog(Blog blog)=>Update(blog);
   
    }
}
