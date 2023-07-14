using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;


namespace EmailSender1
{
    public class EmailSenderService  : BackgroundService
    {
     
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime now = DateTime.Now;
                DateTime scheduledTime = DateTime.Today.AddHours(18); // 8 PM

                if (now > scheduledTime)
                    scheduledTime = scheduledTime.AddDays(1);

                TimeSpan delay = scheduledTime - now;
                await Task.Delay(delay, stoppingToken);

                // Send the email
                SendEmail();
            }
        }

        public void SendEmail()
        {
            using (var message = new MailMessage("jaiden43@ethereal.email", "jaiden43@ethereal.email"))
            {
                message.Subject = "Daily Email";
                message.Body = "This is a sample email.";

                using (var smtpClient = new SmtpClient("smtp.ethereal.email", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("jaiden43@ethereal.email", "Gz6DVD6UuAPKny1YSF");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }
            }
        }
    }
}
