using Entities.Models;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class SubscribeMailRepository : RepositoryBase<SubscribeMail>, ISubscribeMailRepository
    {
        public SubscribeMailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOneSubscribe(SubscribeMail subscribe) => Create(subscribe);
      
    }
}
