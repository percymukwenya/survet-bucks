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
    public class IndustryService : IIndustryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IndustryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<IndustryListResponse>> GetIndustries()
        {
            var response = await _unitOfWork.IndustryRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<IndustryListResponse>>(response);
        }

        public async Task<IndustryDetailResponse> GetIndustry(int id)
        {
            var response = await GetIndustry(id);

            return _mapper.Map<IndustryDetailResponse>(response);
        }        

        public async Task AddIndustry(AddIndustryRequest request)
        {
            var objToCreate = _mapper.Map<Industry>(request);

            await _unitOfWork.IndustryRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateIndustry(UpdateIndustryRequest request)
        {
            var objToUpdate = _mapper.Map<Industry>(request);

            await _unitOfWork.IndustryRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteIndustry(int id)
        {
            var objToDelete = await _unitOfWork.IndustryRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.IndustryRepository.DeleteAsync(objToDelete);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
