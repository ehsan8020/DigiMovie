using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiShop.Areas.Identity.Helpers
{
    public class PersianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "رکورد جاری پیشتر ویرایش شده‌است و تغییرات شما آن‌را بازنویسی خواهد کرد." };
        }

        public override IdentityError DefaultError()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "خطایی رخ داده‌است." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("ایمیل '{0}' هم اکنون مورد استفاده است.", email) };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("نقش '{0}' هم اکنون مورد استفاده‌است.", role) };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("نام کاربری '{0}' هم اکنون مورد استفاده‌است.", userName) };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("ایمیل '{0}' معتبر نیست.", email) };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("نقش '{0}' معتبر نیست.", role) };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "توکن غیر معتبر می باشد." };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("نام کاربری '{0}' معتبر نیست .", userName) };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "این کاربر پیشتر اضافه شده‌است." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کلمه‌ی عبور نامعتبر می باشد." };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کلمه‌ی عبور باید حداقل دارای یک رقم بین 0 تا 9 باشد." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کلمه‌ی عبور باید حداقل دارای یک حرف کوچک انگلیسی باشد." };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کلمه‌ی عبور باید حداقل دارای یک حرف خارج از حروف الفبای انگلیسی و همچنین اعداد باشد." };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کلمه‌ی عبور باید حداقل داراى {0} حرف متفاوت باشد." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کلمه‌ی عبور باید حداقل دارای یک حرف بزرگ انگلیسی باشد." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("کلمه‌ی عبور باید حداقل {0} کاراکتر باشد.", length) };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "بازیابى با شکست مواجه شد." };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کلمه‌ی عبور کاربر پیشتر تنظیم شده‌است." };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = string.Format("کاربر هم اکنون دارای نقش '{0}' است.", role) };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "قفل شدن اکانت برای این کاربر تنظیم نشده‌است." };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "کاربر دارای نقش '{0}' نیست." };
        }
    }
}