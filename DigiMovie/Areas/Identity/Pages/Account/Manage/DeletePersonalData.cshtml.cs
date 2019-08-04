using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DigiMovie.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DigiMovie.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<DigiMovie.Areas.Identity.Data.ApplicationUser> _userManager;
        private readonly SignInManager<DigiMovie.Areas.Identity.Data.ApplicationUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        private readonly IFileManager _ifileManager;

        public DeletePersonalDataModel(
            UserManager<DigiMovie.Areas.Identity.Data.ApplicationUser> userManager,
            SignInManager<DigiMovie.Areas.Identity.Data.ApplicationUser> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            IFileManager ifileManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _ifileManager = ifileManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
            [DataType(DataType.Password)]
            [Display(Name = "کلمه عبور")]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"کاربر با شناسه '{_userManager.GetUserId(User)}' یافت نشد.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"کاربر با شناسه '{_userManager.GetUserId(User)}' یافت نشد.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "کلمه عبور صحیح نمی باشد.");
                    return Page();
                }
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"خطای غیر منتظره در هنگام حذف کاربر با شناسه  '{userId}'.");
            }

            //TODO: Delete Any Related Records in DB (if exists)

            //Delete User's Profile Image
            if (!user.ProfileImagePath.EndsWith("default.png"))
                _ifileManager.DeleteFile(user.ProfileImagePath);

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }
    }
}