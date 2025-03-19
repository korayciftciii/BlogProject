using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string? BlogTitle { get; set; }

        [Required]
        public string? BlogContent { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string? BlogImageUrl { get; set; }

        public DateTime BlogDate { get; set; }=DateTime.Now;

        // Category ile ilişki
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }  // Navigation property

        // Author ile ilişki
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        // Comment ile ilişki
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
