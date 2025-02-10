using kurs_matematyki.Core.Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_matematyki.Core.Services
{
    public class MailService : IMailService
    {
        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            throw new NotImplementedException();
        }
    }
}
