using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class QuestionResponseChoiceRepository : Repository<QuestionResponseChoice>, IQuestionResponseChoiceRepository
    {
        public QuestionResponseChoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
