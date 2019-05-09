using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigiMovie.Models.ViewModels.Categories
{
    public class CreateEditVM
    {
        public Category Category { get; set; }
        public IFormFile Image { get; set; }

    }
}
