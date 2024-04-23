using SurveyBucks.Internal.Infrastructure.Identity.Contracts;
using SurveyBucks.Internal.Infrastructure.Identity.Models.Request;
using SurveyBucks.Internal.Infrastructure.Identity.Models.Response;

namespace SurveyBucks.Internal.Application.Services
{
    public class AuthService : IAuthService
    {
        public Task<ConfirmEmailResponse> ConfirmEmailAsync(string userId, string code)
        {
            throw new NotImplementedException();
        }

        public Task ForgotPassword(ForgotPasswordRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
