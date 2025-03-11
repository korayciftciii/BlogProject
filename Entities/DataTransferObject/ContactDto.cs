using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record class ContactDto
    {
        
        public int ContactId { get; init; }
        
        public string? Name { get; init; }
        
        public string? Surname { get; init; }
        
        public string? Email { get; init; }
        
        public string? Subject { get; init; }
        
        public string? Message { get; init; }
    }
}
