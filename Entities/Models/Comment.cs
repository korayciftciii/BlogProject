using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? UserEmail { get; set; }
        [Required]
        [MaxLength(250)]
        public string? CommentContent { get; set; }
        public DateTime CommentDate { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
