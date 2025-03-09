using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SubscribeMail
    {
        [Key]
        public int MailId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }
    }
}
