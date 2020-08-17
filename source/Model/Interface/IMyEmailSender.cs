using System.Threading.Tasks;

namespace Feedback.API.Model.Interface
{
    public interface IMyEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
