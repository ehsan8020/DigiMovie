﻿using System;
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
        [StringLength(100, ErrorMessage = "عنوان دسته بندی می بایست حداکثر 100 کاراکتر باشد.")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [StringLength(150)]
        [Display(Name = "عکس")]
        public string ImagePath { get; set; }

    }
}
