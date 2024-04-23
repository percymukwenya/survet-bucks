using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface IRewardService
    {
        Task<IReadOnlyList<RewardListResponse>> GetRewards();
        Task<RewardDetailResponse> GetReward(int id);
        Task AddReward(AddRewardRequest request);
        Task UpdateReward(UpdateRewardRequest request);
        Task DeleteReward(int id);
    }
}
