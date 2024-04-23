using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class SurveyParticipationRepository : Repository<SurveyParticipation>, ISurveyParticipationRepository
    {
        public SurveyParticipationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
