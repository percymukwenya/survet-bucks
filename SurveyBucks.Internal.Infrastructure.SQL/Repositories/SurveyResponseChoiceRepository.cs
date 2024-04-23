using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class SurveyResponseChoiceRepository : Repository<SurveyResponseChoice>, ISurveyResponseChoiceRepository
    {
        public SurveyResponseChoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
