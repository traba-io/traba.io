using System.Threading.Tasks;
using Infrastructure.Enum;

namespace Infrastructure.Interface
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, EmailTemplateType templateType, object content);
    }
}