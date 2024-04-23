using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class SurveyStatusRepository : Repository<SurveyStatus>, ISurveyStatusRepository
    {
        public SurveyStatusRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
