using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? AuthorName { get; set; }
        [DataType(DataType.ImageUrl)]
        public string? AuthorImageUrl { get; set; }
        [MaxLength(1500)]
        public string? AuthorAbout { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
