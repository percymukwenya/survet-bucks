using System.ComponentModel.DataAnnotations;

namespace SurveyBucks.Internal.Infrastructure.Identity.Models.Request
{
    public class ForgotPasswordRequest
    {
        [EmailAddress]
        public required string Email { get; set; }
    }
}
