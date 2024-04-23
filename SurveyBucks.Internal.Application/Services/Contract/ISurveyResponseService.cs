using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface ISurveyResponseService
    {
        Task<IReadOnlyList<SurveyResponseListResponse>> GetSurveyResponses();
        Task<SurveyResponseDetailResponse> GetSurveyResponse(int id);
        Task AddSurveyResponse(AddSurveyResponseRequest request);
        Task UpdateSurveyResponse(UpdateSurveyResponseRequest request);
        Task DeleteSurveyResponse(int id);
    }
}
