using System.ComponentModel.DataAnnotations;

namespace SurveyBucks.Internal.Infrastructure.Identity.Models.Request
{
    public class ResetPasswordRequest
    {
        [EmailAddress]
        public required string Email { get; set; }

        public string Token { get; set; }

        [MinLength(6)]
        public required string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }
    }
}
