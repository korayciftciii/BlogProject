﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [MaxLength(1000)]
        public string? AboutContent1 { get; set; }
        public string ContentTitle1 { get; set; }
        [MaxLength(1000)]
        public string? AboutContent2 { get; set; }
        public string ContentTitle2 { get; set; }
        [MaxLength(500)]
        [DataType(DataType.ImageUrl)]
        public string?  AboutImage1 { get; set; }
        [MaxLength(50)]
        [DataType(DataType.ImageUrl)]
        public string? AboutImage2 { get; set; }
        [MaxLength(50)]
        [DataType(DataType.ImageUrl)]
        public string? AboutCarouselImage { get; set; }
    }
}
