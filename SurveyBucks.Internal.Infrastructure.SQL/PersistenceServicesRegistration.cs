using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;
using SurveyBucks.Internal.Infrastructure.SQL.Repositories;

namespace SurveyBucks.Internal.Infrastructure.SQL
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<DapperContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IIndustryRepository, IndustryRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();
            services.AddScoped<IRewardRepository, RewardRepository>();
            services.AddScoped<IRewardTypeRepository, RewardTypeRepository>();
            services.AddScoped<ISurveyParticipationRepository, SurveyParticipationRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<ISurveyResponseRepository, SurveyResponseRepository>();
            services.AddScoped<ISurveyResponseChoiceRepository, SurveyResponseChoiceRepository>();
            services.AddScoped<ISurveyStatusRepository, SurveyStatusRepository>();

            return services;
        }
    }
}
