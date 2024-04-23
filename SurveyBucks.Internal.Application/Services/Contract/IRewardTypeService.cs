using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface IRewardTypeService
    {
        Task<IReadOnlyList<RewardTypeListResponse>> GetRewardTypes();
        Task<RewardTypeDetailResponse> GetRewardType(int id);
        Task AddRewardType(AddRewardTypeRequest request);
        Task UpdateRewardType(UpdateRewardTypeRequest request);
        Task DeleteRewardType(int id);
    }
}
