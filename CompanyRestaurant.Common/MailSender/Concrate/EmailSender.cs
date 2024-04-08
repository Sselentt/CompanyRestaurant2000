using CompanyRestaurant.Common.MailSender.Abstract;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CompanyRestaurant.Common.MailSender.Concrate
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_configuration["EmailSettings:MailServer"],
                                        int.Parse(_configuration["EmailSettings:MailPort"]))
            {
                Credentials = new NetworkCredential(_configuration["EmailSettings:Sender"],
                                                    _configuration["EmailSettings:Password"]),
                EnableSsl = true,
            };

            return client.SendMailAsync(
                new MailMessage(_configuration["EmailSettings:Sender"], email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }
    }
}
