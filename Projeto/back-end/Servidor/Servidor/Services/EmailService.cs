using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Servidor.Security;

namespace Servidor.Services
{
    public class EmailService
    {

        public static void Send(string para, string assunto, string html)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(Settings.Email));
            email.To.Add(MailboxAddress.Parse(para));
            email.Subject = assunto;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(Settings.Email, Settings.EmailPassword);

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
