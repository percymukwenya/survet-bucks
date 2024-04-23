using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class RewardTypeRepository : Repository<RewardType>, IRewardTypeRepository
    {
        public RewardTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
