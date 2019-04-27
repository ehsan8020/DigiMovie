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
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "عنوان محصول می بایست حداکثر 100 کاراکتر باشد.")]
        [StringLength(100, ErrorMessage = "عنوان محصول می بایست حداکثر 100 کاراکتر باشد.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفاً مشخصات محصول را وارد نمایید.")]
        public string Specification { get; set; }

        public bool IsExists { get; set; }

        [Required(ErrorMessage = "لطفاً تعداد موجود محصول را وارد نمایید.")]
        public short NumberInStock { get; set; }

        //[Range(10,20,ErrorMessage ="")]
        //[Url(ErrorMessage ="")]
        //[EmailAddress(ErrorMessage ="")]
        //[RegularExpression("\\d{3,5}" , ErrorMessage ="")]
        //[Compare("Password" , ErrorMessage ="")]
        [Required(ErrorMessage = "لطفاً قیمت محصول را وارد نمایید.")]
        public int Price { get; set; }
    }
}
