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
        [Required]
        public string? Education { get; set; }
        [Required]
        public string? Location { get; set; }
        public string? Occupation { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? AuthorEmail { get; set; }
        public string? Skill1 { get; set; }
        public string? Skill2 { get; set; }
        public string? Skill3 { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime AuthorInsertionDate { get; set; }
        [DataType(DataType.Url)]
        public string? InsatagramLink { get; set; }
        [DataType(DataType.Url)]
        public string? XLink { get; set; }
        [DataType(DataType.Url)]
        public string? FacebookLink { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
