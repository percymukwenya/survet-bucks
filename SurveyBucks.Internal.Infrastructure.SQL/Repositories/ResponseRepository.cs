using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class ResponseRepository : Repository<SurveyResponse>, IResponseRepository
    {
        public ResponseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
