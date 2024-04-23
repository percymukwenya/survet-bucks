using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface ISurveyParticipationService
    {
        Task<IReadOnlyList<SurveyParticipationListResponse>> GetSurveyParticipations();
        Task<SurveyParticipationDetailResponse> GetSurveyParticipation(int id);
        Task AddSurveyParticipation(AddSurveyParticipationRequest request);
        Task UpdateSurveyParticipation(UpdateSurveyParticipationRequest request);
        Task DeleteSurveyParticipation(int id);
    }
}
