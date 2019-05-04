using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigiMovie.Extensions
{
    public static class IFormFileExtensions
    {
        public static void Check(this IFormFile file, long maxSize, string[] allowedTypes)
        {
            if (file == null || file.Length == 0)
                throw new Exception("فایلی انتخاب نشده است.");

            if (file.Length > maxSize)
                throw new Exception("فایل انتخاب شده بزرگتر از حد مجاز می باشد.");

            if (!allowedTypes.Contains(file.ContentType))
                throw new Exception("فایل انتخاب شده برای محصول در قالب مجاز نمی باشد.");
        }
    }
}
