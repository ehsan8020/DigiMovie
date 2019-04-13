using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace DigiMovie.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Specification { get; set; }

        public bool IsExists { get; set; }

        public short NumberInStock { get; set; }

        public int Price { get; set; }
    }
}
