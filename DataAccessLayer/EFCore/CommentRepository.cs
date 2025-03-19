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
  public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public void CreateOneComment(Comment comment) => Create(comment);

        public void DeleteOneComment(Comment comment)=>Delete(comment);
       

        public async Task<IQueryable<Comment>> GetAllCommentsAsync(bool trackChanges) => await Task.FromResult(FindAll(trackChanges));


        public async Task<IEnumerable<Comment>> GetCommentsByIdAsync(int blogId, bool trackChanges)
        {
            var comments = await FindAll(trackChanges).ToListAsync();
            var commentsById = comments.Where(a => a.BlogId.Equals(blogId));
            return commentsById;
        }

        public async Task<Comment> GetOneCommentByIdAsync(int commentId, bool trackChanges)=> await FindByCondition(a => a.CommentId.Equals(commentId), trackChanges).SingleOrDefaultAsync();

    }
}
