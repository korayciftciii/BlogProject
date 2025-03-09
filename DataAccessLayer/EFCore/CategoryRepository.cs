using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CategoryRepository :RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOneCategory(Category category) => Create(category);
      

        public void DeleteOneCategory(Category category)=>Delete(category);


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await FindAll(trackChanges).ToListAsync();
            return categories;
        }
        
        public async Task<Category> GetCategoryByIdAsync(int categoryId, bool trackChanges)=> await FindByCondition(b => b.CategoryId.Equals(categoryId), trackChanges).SingleOrDefaultAsync();


        public void UpdateOneCategory(Category category)=>Update(category);
        
    }
}
