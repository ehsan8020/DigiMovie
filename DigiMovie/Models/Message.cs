using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigiMovie.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [StringLength(100, ErrorMessage = "{0} می بایست حداکثر {1} کاراکتر باشد.")]
        [Display(Name ="نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [StringLength(100, ErrorMessage = "{0} می بایست حداکثر {1} کاراکتر باشد.")]
        [EmailAddress(ErrorMessage = "لطفاً در قالب {0} وارد نمایید.")]
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [StringLength(200, ErrorMessage = "{0} می بایست حداکثر {1} کاراکتر باشد.")]
        [Display(Name = "موضوع")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [StringLength(2000, ErrorMessage = "{0} می بایست حداکثر {1} کاراکتر باشد.")]
        [Display(Name = "متن پیام")]
        public string Body { get; set; }

        [Display(Name = "زمان ثبتی")]
        public DateTime RegisteredTime { get; set; }

        [Display(Name = "خوانده شده")]
        public bool IsRead { get; set; }

        [Display(Name = "ستاره دار")]
        public bool IsStarred { get; set; }

    }
}
