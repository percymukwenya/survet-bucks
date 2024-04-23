using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface IIndustryService
    {
        Task<IReadOnlyList<IndustryListResponse>> GetIndustries();
        Task<IndustryDetailResponse> GetIndustry(int id);
        Task AddIndustry(AddIndustryRequest request);
        Task UpdateIndustry(UpdateIndustryRequest request);
        Task DeleteIndustry(int id);
    }
}
