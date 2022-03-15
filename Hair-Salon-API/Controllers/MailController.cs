using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Salon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController:ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
