using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace DigiMovie.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [StringLength(100, ErrorMessage = "{0} می بایست حداکثر {1} کاراکتر باشد.")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [Display(Name = "مشخصات")]
        public string Specification { get; set; }

        [Display(Name ="موجود")]
        public bool IsExists { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [Range(0,32000,ErrorMessage = "{0} می بایست بین {1} و {2} باشد.")]
        [Display(Name = "تعداد موجود")]
        public short NumberInStock { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [Display(Name ="قیمت (ریال)")]
        [Range(0, 2000000000, ErrorMessage = "{0} می بایست بین {1} و {2} باشد.")]
        public int Price { get; set; }

        [StringLength(150)]
        [Display(Name ="عکس")]
        public string ImagePath { get; set; }

        #region Relationships
        [ForeignKey("CatId")]
        public Category Category { get; set; }

        [Display(Name ="دسته بندی")]
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        public int CatId { get; set; }
        #endregion
    }
}
