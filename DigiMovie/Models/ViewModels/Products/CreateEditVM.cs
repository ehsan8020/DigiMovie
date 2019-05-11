using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
