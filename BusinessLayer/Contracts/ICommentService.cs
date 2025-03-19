using Entities.DataTransferObject;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsByIdAsync(int id, bool trackChanges);
        Task<CommentDto> CreateOneCommentAsync(CommentDtoForInsertion commentDto);
        Task<Comment> GetOneCommentByIdAsync(int commentId, bool trackChanges);
        Task DeleteOneCommentAsync(int id, bool trackChanges);
    }
}
