using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigiMovie.Models.ViewModels.Products
{
    public class CreateEditVM
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
    }
}
