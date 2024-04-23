using Microsoft.Extensions.DependencyInjection;
using SurveyBucks.Internal.Application.Services;
using SurveyBucks.Internal.Application.Services.Contract;
using System.Reflection;

namespace SurveyBucks.Internal.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IIndustryService, IndustryService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionTypeService, QuestionTypeService>();
            services.AddScoped<IQuestionResponseChoiceService, QuestionResponseChoiceService>();
            services.AddScoped<IRewardService, RewardService>();
            services.AddScoped<IRewardTypeService, RewardTypeService>();
            services.AddScoped<ISurveyParticipationService, SurveyParticipationService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<ISurveyResponseService, SurveyResponseService>();                    
            services.AddScoped<ISurveyStatusService, SurveyStatusService>();

            return services;
        }
    }
}
