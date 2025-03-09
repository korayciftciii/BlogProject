using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CategoryName { get; set; }

        [Required]
        [MaxLength(200)]
        public string? CategoryDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? CategoryImgUrl { get; set; }

        // Bloglarla ilişki
        public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    }
}
