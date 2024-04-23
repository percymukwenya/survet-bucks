using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class ResponseChoiceRepository : Repository<SurveyResponseChoice>, ISurveyResponseChoiceRepository
    {
        public ResponseChoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
