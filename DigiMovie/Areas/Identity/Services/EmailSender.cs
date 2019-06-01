using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace DigiMovie.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //1-Set Email Message
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("mftaspnet@gmail.com", "DigiMovie");
            mailMessage.Sender = new MailAddress("mftaspnet@gmail.com", "DigiMovie");
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            //mailMessage.Bcc.Add("");

            //2- Set SmtpClient
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential() { UserName = "mftaspnet@gmail.com", Password = "qwQW12!@" }
            };



            //3- Send Email
            await smtp.SendMailAsync(mailMessage);

        }
    }
}
