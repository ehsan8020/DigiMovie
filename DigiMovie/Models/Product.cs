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

        [Required(ErrorMessage = "لطفاً عنوان محصول را وارد نمایید.")]
        [StringLength(100, ErrorMessage = "عنوان محصول می بایست حداکثر 100 کاراکتر باشد.")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفاً مشخصات محصول را وارد نمایید.")]
        [Display(Name = "مشخصات")]
        public string Specification { get; set; }

        [Display(Name ="موجود")]
        public bool IsExists { get; set; }

        [Required(ErrorMessage = "لطفاً تعداد موجود محصول را وارد نمایید.")]
        [Range(0,32000,ErrorMessage ="تعداد موجود محصول می بایست حداکثر 32000 باشد.")]
        [Display(Name = "تعداد موجود")]
        public short NumberInStock { get; set; }

        [Required(ErrorMessage = "لطفاً قیمت محصول را وارد نمایید.")]
        [Display(Name ="قیمت (ریال)")]
        [Range(0, 2000000000, ErrorMessage = "قیمت محصول می بایست حداکثر 2000000000 ریال باشد.")]
        public int Price { get; set; }
    }
}
