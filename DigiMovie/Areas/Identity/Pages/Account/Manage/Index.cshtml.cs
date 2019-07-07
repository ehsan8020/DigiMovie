using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DigiMovie.Services.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiMovie.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<DigiMovie.Areas.Identity.Data.ApplicationUser> _userManager;
        private readonly SignInManager<DigiMovie.Areas.Identity.Data.ApplicationUser> _signInManager;
        private readonly ISiteEmailSender _emailSender;

        public IndexModel(
            UserManager<DigiMovie.Areas.Identity.Data.ApplicationUser> userManager,
            SignInManager<DigiMovie.Areas.Identity.Data.ApplicationUser> signInManager,
            ISiteEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [EmailAddress(ErrorMessage = "لطفاً در قالب {0} وارد نمایید.")]
            [Display(Name = "پست الکترونیکی")]
            public string Email { get; set; }

            [Phone(ErrorMessage = "لطفاً در قالب {0} وارد نمایید.")]
            [Display(Name = "شماره تلفن")]
            public string PhoneNumber { get; set; }


            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [StringLength(100, ErrorMessage = "{0} می بایست حداکثر {1} کاراکتر باشد.")]
            [Display(Name = "نام")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [StringLength(100, ErrorMessage = "{0} می بایست حداکثر {1} کاراکتر باشد.")]
            [Display(Name = "نام خانوادگی")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [Display(Name = "تاریخ تولد")]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [Display(Name = "جنسیت")]
            public bool IsMale { get; set; }

            [Display(Name = "زمان عضویت")]
            public DateTime RegisteredDateTime { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"کاربر با شناسه '{_userManager.GetUserId(User)}' یافت نشد.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                IsMale = user.IsMale,
                RegisteredDateTime = user.RegisteredDateTime
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"کاربر با شناسه '{_userManager.GetUserId(User)}' یافت نشد.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"خطای غیر منتظره در هنگام تنظیم پست الکترونیکی کاربر با شناسه '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"خطای غیر منتظره در هنگام تنظیم شماره تلفن کاربر با شناسه '{userId}'.");
                }
            }

            if (user.FirstName != Input.FirstName)
                user.FirstName = Input.FirstName;

            if (user.LastName != Input.LastName)
                user.LastName = Input.LastName;

            if (user.BirthDate != Input.BirthDate)
                user.BirthDate = Input.BirthDate;

            if (user.IsMale != Input.IsMale)
                user.IsMale = Input.IsMale;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "نمایه شخصی شما بروزرسانی گردید.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"کاربر با شناسه '{_userManager.GetUserId(User)}' یافت نشد.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);


            //await _emailSender.SendEmailAsync(
            //    email,
            //    "Confirm your email",
            //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            await _emailSender.SendAsync(DigiMovie.Helpers.EmailTypes.Info,
                       email,
                       "تایید حساب کاربری",
                       $"لطفاً حساب کاربری خود را با کلیک بر روی  <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>این لینک</a> فعال نمایید.");

            StatusMessage = "ایمیل فعالسازی ارسال گردید. لطفاً ایمیل خود را بررسی فرمائید.";
            return RedirectToPage();
        }
    }
}
