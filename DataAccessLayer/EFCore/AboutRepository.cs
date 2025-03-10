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
    public class AboutRepository :RepositoryBase<About>,IAboutRepository
    {
        public AboutRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<About>> GetAboutContentAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();
      
    }
}
