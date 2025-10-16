using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace BarberShop1._0._1.Web.Services
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromAddress = _configuration["EmailSettings:DefaultEmailAddress"];
            var smtpServer = _configuration["EmailSettings:Server"];
            var smtpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);
            var enableSsl = Convert.ToBoolean(_configuration["EmailSettings:EnableSsl"]);

            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(fromAddress),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };

                message.To.Add(new MailAddress(email));

                using var client = new SmtpClient(smtpServer, smtpPort)
                {
                    EnableSsl = enableSsl, // Enable SSL for secure communication
                    UseDefaultCredentials = true
                };

                await client.SendMailAsync(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }
        }
    }
}
