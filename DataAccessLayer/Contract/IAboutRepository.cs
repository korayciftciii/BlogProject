﻿using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IAboutRepository :IRepositoryBase<About>
    {
        Task<IEnumerable<About>> GetAboutContentAsync(bool trackChanges);
    }
}
