using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface ISurveyStatusService
    {
        Task<IReadOnlyList<SurveyStatusListResponse>> GetSurveyStatuses();
        Task<SurveyStatusDetailResponse> GetSurveyStatus(int id);
        Task AddSurveyStatus(AddSurveyStatusRequest request);
        Task UpdateSurveyStatus(UpdateSurveyStatusRequest request);
        Task DeleteSurveyStatus(int id);
    }
}
