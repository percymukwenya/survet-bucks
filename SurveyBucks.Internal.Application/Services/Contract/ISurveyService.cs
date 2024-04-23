using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface ISurveyService
    {
        Task<IReadOnlyList<SurveyListResponse>> GetSurveys();
        Task<SurveyDetailResponse> GetSurvey(int id);
        Task AddSurvey(AddSurveyRequest request);
        Task UpdateSurvey(UpdateSurveyRequest request);
        Task DeleteSurvey(int id);
    }
}
