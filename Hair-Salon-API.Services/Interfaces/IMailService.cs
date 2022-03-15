using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
