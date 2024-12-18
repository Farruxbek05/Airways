using Airways.Application.Common.Email;

namespace Airways.Application.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
