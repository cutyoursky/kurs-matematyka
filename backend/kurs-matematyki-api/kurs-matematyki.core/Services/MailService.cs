using kurs_matematyki.Core.Services.ServiceContracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;



namespace kurs_matematyki.Core.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var fromEmail = Environment.GetEnvironmentVariable("SENDGRID_EMAIL");
            var password = _configuration["EmailConfiguration:Password"];
            var host = _configuration["EmailConfiguration:Host"];
            var port = _configuration.GetValue<int>("EmailConfiguration:Port");
            
            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromEmail, password);

            var message = new MailMessage(fromEmail!, toEmail, subject, content);
            message.IsBodyHtml = true;
            await smtpClient.SendMailAsync(message);
        }
    }
}
