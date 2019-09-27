using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HiShop.Services.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HiShop.Areas.Identity.Pages.Account
{
    public class UnconfirmedUserModel : PageModel
    {
        private readonly UserManager<HiShop.Areas.Identity.Data.ApplicationUser> _userManager;
        private readonly ISiteEmailSender _emailSender;

        public UnconfirmedUserModel(UserManager<HiShop.Areas.Identity.Data.ApplicationUser> userManager, ISiteEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string userId)
        {
            if (userId == null)
                return RedirectToPage("/Index");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound($"کاربر با شناسه '{userId}' یافت نشد.");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = user.Id, code = code },
                protocol: Request.Scheme);

            //await _emailSender.SendEmailAsync(user.Email, "تایید حساب کاربری",
            //    $"لطفاً حساب کاربری خود را با کلیک بر روی  <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>این لینک</a> فعال نمایید.");

            await _emailSender.SendAsync(HiShop.Helpers.EmailTypes.Info,
                       user.Email,
                       "تایید حساب کاربری",
                       $"لطفاً حساب کاربری خود را با کلیک بر روی  <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>این لینک</a> فعال نمایید.");

            ViewData["EmailStatus"] = "ایمیل فعالسازی حساب کاربری مجدداْ ارسال گردید.";
            return Page();
        }
    }
}