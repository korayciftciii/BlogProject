using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
  public interface IAuthorRepository:IRepositoryBase<Author>
    {
        Task<Author> GetAuthorByIdAsync(int id, bool trackChanges);
        Task<IQueryable<Author>> GetAllAuthorsAsync(bool trackChanges);
    }
}
