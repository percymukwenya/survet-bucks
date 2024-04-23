using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
