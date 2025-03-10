using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AboutManager : IAboutService
    {
        private readonly IRepositoryManager _repositoryManager;
        public AboutManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
           
        }

        public async Task<IEnumerable<About>> GetAboutContentAsync(bool trackChanges)
        {
            var content = await _repositoryManager.About.GetAboutContentAsync(trackChanges);
            return content;
        }
    }
}
