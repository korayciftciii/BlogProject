using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogManager  :IBlogService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public BlogManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BlogDto> CreateOneBlogAsync(BlogDtoForInsertion blogDto)
        {
            if (blogDto == null)
            {

                throw new ArgumentNullException(nameof(blogDto));
            }
            var entity = _mapper.Map<Blog>(blogDto);
            _repositoryManager.Blog.CreateOneBlog(entity);

            await _repositoryManager.SaveAsync();

            return _mapper.Map<BlogDto>(entity);
        }

        public async Task DeleteOneBlogAsync(int id, bool trackChanges)
        {
            var blog = await _repositoryManager.Blog.GetBlogByIdAsync(id,trackChanges);

            _repositoryManager.Blog.DeleteOneBlog(blog);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllBlogAsync(bool trackChanges)
        {

            var blogs = await _repositoryManager.Blog.GetAllBlogAsync(trackChanges);
            var blogList = blogs.Include(b => b.Category)
                                .Include(b => b.Author)
                                .ToList();
            return blogList;
        }

        public async Task<Blog> GetBlogByIdAsync(int id, bool trackChanges)
        {
            var blogs = await _repositoryManager.Blog.GetAllBlogAsync(trackChanges);  // Task çözülüyor
            var blog = await blogs.Include(b => b.Category)
                                  .Include(b => b.Author)
                                  .FirstOrDefaultAsync(b => b.BlogId == id);

            return blog;
        }

        public async Task UpdateOneBlogAsync(int id, BlogDtoForUpdate blogDto, bool trackChanges)
        {
            var model = await GetBlogByIdAsync(id, trackChanges);
            if (model == null)
            {

                throw new ArgumentNullException();
            }
            if (blogDto == null)
            {

                throw new ArgumentNullException(nameof(blogDto));
            }

            // Yeni nesne oluşturmak yerine mevcut nesneyi güncelle
            _mapper.Map(blogDto, model);

            _repositoryManager.Blog.Update(model);
            await _repositoryManager.SaveAsync();
        }
    }
}
