using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record class CategoryDto
    {
        public int CategoryId { get; init; }
        public string? CategoryName { get; init; }
      
    }
}
