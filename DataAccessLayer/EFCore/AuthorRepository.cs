using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class AuthorRepository :RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IQueryable<Author>> GetAllAuthorsAsync(bool trackChanges) => await Task.FromResult(FindAll(trackChanges));


        public async Task<Author> GetAuthorByIdAsync(int id, bool trackChanges) => await FindByCondition(a => a.AuthorId.Equals(id), trackChanges).SingleOrDefaultAsync();
     
    }
    
    
}
