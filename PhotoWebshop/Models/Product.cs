using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoWebshop.Models
{
    public class Product
    {
        [Key]
        public string Title { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

    }
}
