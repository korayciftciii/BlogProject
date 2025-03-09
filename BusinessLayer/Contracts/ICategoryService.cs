using Entities.DataTransferObject;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetCategoryByIdAsync(int id, bool trackChanges);
        Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDto);
        Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto, bool trackChanges);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
    }
}
