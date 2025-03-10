﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
   public interface IAboutService
    {
        Task<IEnumerable<About>> GetAboutContentAsync(bool trackChanges);
    }
}
