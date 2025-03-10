using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record class CommentDto
    {
        
        public int CommentId { get; init; }
        
        public string? UserName { get; init; }
        
        public string? UserEmail { get; init; }
        
        
        public string? CommentContent { get; init; }
        public DateTime CommentDate { get; init; }

        public int BlogId { get; init; }
        
    }
}
