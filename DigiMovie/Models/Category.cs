using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DigiMovie.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [StringLength(100, ErrorMessage = "نام دسته بندی می بایست حداکثر 100 کاراکتر باشد.")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
