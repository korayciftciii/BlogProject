using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        
        public string? AdminUserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? AdminEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? AdminPassword { get; set; }
    }
}
