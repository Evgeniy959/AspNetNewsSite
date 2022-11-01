using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetNewsSite.Models
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string content)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("NewsSite Admin", "evgpilipenkoY@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("News Client", email));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = content
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            //using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("evgpilipenkoY@yandex.ru", "tdutybq21@");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
