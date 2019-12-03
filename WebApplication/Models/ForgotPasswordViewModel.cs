using System.ComponentModel.DataAnnotations;
using SendGrid.Helpers.Mail;

namespace WebApplication.Models
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}