using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmailSender1
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmailController : ControllerBase
    {
        private readonly EmailSenderService _emailSenderService;

        public EmailController(EmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        [HttpPost]
        public IActionResult TriggerEmailSending()
        {
            // Start the email sending task
            Task.Run(() => _emailSenderService.SendEmail());

            return Ok("Email sending triggered successfully!");
        }
    }
}
