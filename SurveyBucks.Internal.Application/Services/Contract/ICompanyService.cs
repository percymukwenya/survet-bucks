using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface ICompanyService
    {
        Task<IReadOnlyList<CompanyListResponse>> GetCompanies();
        Task<CompanyDetailResponse> GetCompany(int id);
        Task AddCompany(AddCompanyRequest request);
        Task UpdateCompany(UpdateCompanyRequest request);
        Task DeleteCompany(int id);
    }
}
