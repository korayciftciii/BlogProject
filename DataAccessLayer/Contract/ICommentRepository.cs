using Entities.Models;
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
        Task<IQueryable<Comment>> GetAllCommentsAsync(bool trackChanges);
        Task<IEnumerable<Comment>> GetCommentsByIdAsync(int commentId, bool trackChanges);
        Task<Comment> GetOneCommentByIdAsync(int commentId, bool trackChanges);
        void CreateOneComment(Comment comment);
        void DeleteOneComment(Comment comment);
    }
}
