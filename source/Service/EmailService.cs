using Feedback.API.Model.Interface;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Feedback.API.Service
{
    public class EmailService : IMyEmailSender
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = _config["EMailBilgileri:EPostaAdresi"],
                        Password = _config["EMailBilgileri:EPostaSifresi"]
                    };

                    client.Host = _config["EMailBilgileri:Host"];
                    client.Port = int.Parse(_config["EMailBilgileri:Port"]);
                    client.EnableSsl = true;
                    client.TargetName = _config["EMailBilgileri:TargetName"];
                    client.UseDefaultCredentials = false;
                    client.Credentials = credential;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(email));
                        emailMessage.From = new MailAddress(_config["EMailBilgileri:EPostaAdresi"]);
                        emailMessage.Subject = subject;
                        emailMessage.Body = htmlMessage;

                        await client.SendMailAsync(emailMessage);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Fatal("SendEmailError . Email : {0} . Subject : {1} . HtmlMessage : {2} ", email, subject, htmlMessage);
            }
        }
    }
}
