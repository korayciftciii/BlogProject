using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CategoryManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDto)
        {
            if (categoryDto == null)
            {
               
                throw new ArgumentNullException(nameof(categoryDto));
            }
            var entity = _mapper.Map<Category>(categoryDto);
            _repositoryManager.Category.CreateOneCategory(entity);
            await _repositoryManager.SaveAsync();
            
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var category = await _repositoryManager.Category.GetCategoryByIdAsync(id,trackChanges);

            _repositoryManager.Category.DeleteOneCategory(category);
            await _repositoryManager.SaveAsync();
            
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {


            var categories = await _repositoryManager.Category.GetAllCategoriesAsync(trackChanges);
            var categoryList = categories.Include(b => b.Blogs)
                                .ToList();
            return categoryList;
        
        
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool trackChanges)
        {

            var category = await _repositoryManager.Category.GetCategoryByIdAsync(id, trackChanges);
            return category;
        }

        public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto, bool trackChanges)
        {
            var model = await GetCategoryByIdAsync(id, trackChanges);
            if (model == null)
            {
                
                throw new ArgumentNullException();
            }
            if (categoryDto == null)
            {
               
                throw new ArgumentNullException(nameof(categoryDto));
            }

            // Yeni nesne oluşturmak yerine mevcut nesneyi güncelle
            _mapper.Map(categoryDto, model);

            _repositoryManager.Category.Update(model);
            await _repositoryManager.SaveAsync();
           
        }
    }
}
