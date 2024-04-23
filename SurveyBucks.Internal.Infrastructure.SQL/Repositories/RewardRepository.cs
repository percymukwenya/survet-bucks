using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class RewardRepository : Repository<Reward>, IRewardRepository
    {
        public RewardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
