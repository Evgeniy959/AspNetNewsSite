using System.Threading.Tasks;

namespace AspNetNewsSite.Models
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string content);
    }
}