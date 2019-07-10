using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DigiMovie.Services.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DigiMovie.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Data.ApplicationUser> _signInManager;
        private readonly UserManager<DigiMovie.Areas.Identity.Data.ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        private readonly ISiteEmailSender _emailSender;

        public RegisterModel(
            UserManager<DigiMovie.Areas.Identity.Data.ApplicationUser> userManager,
            SignInManager<DigiMovie.Areas.Identity.Data.ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            ISiteEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        //public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [EmailAddress(ErrorMessage = "لطفاً در قالب {0} وارد نمایید.")]
            [Display(Name = "پست الکترونیکی")]
            public string Email { get; set; }

            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [StringLength(100, ErrorMessage = "{0} می بایست بین {2} و {1} کاراکتر باشد.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "کلمه عبور")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "تکرار کلمه عبور")]
            [Compare("Password", ErrorMessage = "کلمه عبور و تکرار کلمه عبور می بایست با هم برابر باشند.")]
            public string ConfirmPassword { get; set; }

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
        }

        public void OnGet()
        {
            //ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new DigiMovie.Areas.Identity.Data.ApplicationUser {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName ,
                    LastName = Input.LastName , 
                    BirthDate = Input.BirthDate,
                    IsMale = Input.IsMale,
                    RegisteredDateTime = DateTime.Now ,
                    ProfileImagePath =  "/UserUploads/UsersProfile/default.png"
            };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "تایید حساب کاربری",
                    //    $"لطفاً حساب کاربری خود را با کلیک بر روی  <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>این لینک</a> فعال نمایید.");

                    await _emailSender.SendAsync(DigiMovie.Helpers.EmailTypes.Info  ,
                        Input.Email ,
                        "تایید حساب کاربری" ,
                        $"لطفاً حساب کاربری خود را با کلیک بر روی  <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>این لینک</a> فعال نمایید.");

                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    //User have to go check his/her email
                    return RedirectToPage("./UnconfirmedUser", new { userId = user.Id });


                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}