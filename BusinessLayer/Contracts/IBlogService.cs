using Entities.DataTransferObject;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBlogService 
    {
        Task<IEnumerable<Blog>> GetAllBlogAsync(bool trackChanges);
        Task<Blog> GetBlogByIdAsync(int id, bool trackChanges);
        Task<BlogDto> CreateOneBlogAsync(BlogDtoForInsertion blogDto);
        Task UpdateOneBlogAsync(int id, BlogDtoForUpdate blogDto, bool trackChanges);
        Task DeleteOneBlogAsync(int id, bool trackChanges);
    }
}
