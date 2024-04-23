using AutoMapper;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using SurveyBucks.Internal.Application.Services.Contract;
using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CompanyListResponse>> GetCompanies()
        {
            var response = await _unitOfWork.CompanyRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<CompanyListResponse>>(response);
        }

        public async Task<CompanyDetailResponse> GetCompany(int id)
        {
            var response = await GetCompany(id);

            return _mapper.Map<CompanyDetailResponse>(response);
        }

        public async Task AddCompany(AddCompanyRequest request)
        {
            var objToCreate = _mapper.Map<Company>(request);

            await _unitOfWork.CompanyRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCompany(UpdateCompanyRequest request)
        {
            var objToUpdate = _mapper.Map<Company>(request);

            await _unitOfWork.CompanyRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCompany(int id)
        {
            var objToDelete = await _unitOfWork.CompanyRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.CompanyRepository.DeleteAsync(objToDelete);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
