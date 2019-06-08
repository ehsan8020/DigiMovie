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
            //1- Set Email Message
            var mailMessage = new MailMessage();
            mailMessage.From = DigiMovie.Helpers.EmailSettings.GetMailAddress(DigiMovie.Helpers.EmailTypes.Info);
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = htmlMessage;
            //mailMessage.Bcc.Add("");

            //2- Set SmtpClient
            var smtp =  DigiMovie.Helpers.EmailSettings.GetSmtpClient(DigiMovie.Helpers.EmailTypes.Info);

            //3- Send Email
            await smtp.SendMailAsync(mailMessage);
        }
    }
}
