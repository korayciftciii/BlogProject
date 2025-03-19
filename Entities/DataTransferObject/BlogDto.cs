using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record class BlogDto
    {
        
        public int BlogId { get; init; }
        public string? BlogTitle { get; init; }
        public string? BlogContent { get; init; }
        public string? BlogImageUrl { get; set; }

        public DateTime BlogDate { get; init; } = DateTime.Now;
        public int CategoryId { get; init; }
     

        public int AuthorId { get; init; }
      

       
    }
}
