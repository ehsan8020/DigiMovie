using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HiShop.Services.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HiShop.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<HiShop.Areas.Identity.Data.ApplicationUser> _userManager;
        private readonly ISiteEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<HiShop.Areas.Identity.Data.ApplicationUser> userManager, ISiteEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [EmailAddress(ErrorMessage = "لطفاً در قالب {0} وارد نمایید.")]
            [Display(Name = "پست الکترونیکی")]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(
                //    Input.Email,
                //    "بازنشانی کلمه عبور",
                //    $"لطفاْ کلمه عبور خود را از <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>اینجا</a> تغییر دهید.");

                await _emailSender.SendAsync(HiShop.Helpers.EmailTypes.Info,
                       Input.Email,
                       "بازنشانی کلمه عبور",
                       $"لطفاْ کلمه عبور خود را از <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>اینجا</a> تغییر دهید.");

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
