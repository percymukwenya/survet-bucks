using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class SurveyResponseRepository : Repository<SurveyParticipation>, ISurveyResponseRepository
    {
        public SurveyResponseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
