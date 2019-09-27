using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HiShop.Helpers
{
    public enum EmailTypes : byte
    {
        Info, Support, NoReply, Newsletter
    }

    public class EmailSettings
    {
        public static MailAddress GetMailAddress(EmailTypes type)
        {
            if(type == EmailTypes.Info)
                return new MailAddress("mftaspnet@gmail.com", "های شاپ");
            else if (type == EmailTypes.Newsletter)
                return new MailAddress("newsletter@gmail.com", "های شاپ");
            else if (type == EmailTypes.NoReply)
                return new MailAddress("no-reply@gmail.com", "های شاپ");
            else 
                return new MailAddress("support@gmail.com", "های شاپ");
        }
        public static SmtpClient GetSmtpClient(EmailTypes type)
        {
            if (type == EmailTypes.Info)
                return new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential() { UserName = "mftaspnet@gmail.com", Password = "qwQW12!@" }
                };
            else if (type == EmailTypes.Newsletter)
                return new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential() { UserName = "newsletter@gmail.com", Password = "ferew" }
                };
            else if (type == EmailTypes.NoReply)
                return new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential() { UserName = "no-reply@gmail.com", Password = "12312312" }
                };
            else
                return new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential() { UserName = "support@gmail.com", Password = "gfdsffvb" }
                };
        }
    }
}
