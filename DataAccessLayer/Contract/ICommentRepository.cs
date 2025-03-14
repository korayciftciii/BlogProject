﻿using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByIdAsync(int commentId, bool trackChanges);
        void CreateOneComment(Comment comment);
    }
}
