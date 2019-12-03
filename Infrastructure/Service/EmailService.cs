using System;
using System.Threading.Tasks;
using Domain.Util;
using Infrastructure.Enum;
using Infrastructure.Interface;
using Infrastructure.Util;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.Service
{
    public class EmailService : IEmailService, IDisposable
    {
        private SendGridClient _sendGridClient;
        public EmailService()
        {
            _sendGridClient = new SendGridClient(EnvironmentVariables.SendGridApiKey ?? "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");
        }
        public async Task SendEmail(string to, string subject, EmailTemplateType templateType, object content)
        {
            var from = new EmailAddress("nao-responda@traba.io", "traba.io");
            var messageContent = TemplateUtils.FormatTemplate(templateType, content);
            var message = new SendGridMessage()
            {
                From = from,
                Subject = subject,
                HtmlContent = messageContent
            };
            message.AddTo(new EmailAddress(to));
            await _sendGridClient.SendEmailAsync(message);
        }

        public void Dispose()
        {
            _sendGridClient = null;
        }
    }
}