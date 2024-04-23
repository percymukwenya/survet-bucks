using SurveyBucks.Internal.Infrastructure.Identity.Models.Request;
using SurveyBucks.Internal.Infrastructure.Identity.Models.Response;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<ConfirmEmailResponse> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model);
        Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest model);
    }
}
