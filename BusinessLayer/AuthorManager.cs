using AutoMapper;
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
    public class AuthorManager : IAuthorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public AuthorManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges)
        {
            var authors = await _repositoryManager.Author.GetAllAuthorsAsync(trackChanges);
           
            return authors;
        }

        public async Task<Author> GetAuthorByIdAsync(int id, bool trackChanges)
        {
            var authors = await _repositoryManager.Author.GetAllAuthorsAsync(trackChanges);
            var author = await authors.Include(b => b.Blogs).FirstOrDefaultAsync(b => b.AuthorId.Equals(id));
            return author;
        }
    }
}
