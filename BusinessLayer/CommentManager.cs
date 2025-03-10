using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentManager :ICommentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CommentManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateOneCommentAsync(CommentDtoForInsertion commentDto)
        {
         if(commentDto==null)
            {
                throw new ArgumentNullException(nameof(commentDto));
            }
            var entity = _mapper.Map<Comment>(commentDto);
            _repositoryManager.Comment.CreateOneComment(entity);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<CommentDto>(entity);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByIdAsync(int id, bool trackChanges)
        {

            var comment = await _repositoryManager.Comment.GetCommentsByIdAsync(id,trackChanges);
            
            return comment;
        }
    }
}
