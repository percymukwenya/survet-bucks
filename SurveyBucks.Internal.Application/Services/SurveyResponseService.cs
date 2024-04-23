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
    public class SurveyResponseService : ISurveyResponseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyResponseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }       

        public async Task<SurveyResponseDetailResponse> GetSurveyResponse(int id)
        {
            var response = await _unitOfWork.SurveyResponseRepository.GetByIdAsync(id);

            return _mapper.Map<SurveyResponseDetailResponse>(response);
        }

        public async Task<IReadOnlyList<SurveyResponseListResponse>> GetSurveyResponses()
        {
            var response = await _unitOfWork.SurveyResponseRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<SurveyResponseListResponse>>(response);
        }

        public async Task AddSurveyResponse(AddSurveyResponseRequest request)
        {
            var objToCreate = _mapper.Map<SurveyResponse>(request);

            await _unitOfWork.SurveyResponseRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateSurveyResponse(UpdateSurveyResponseRequest request)
        {
            var objToUpdate = _mapper.Map<SurveyResponse>(request);

            await _unitOfWork.SurveyResponseRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSurveyResponse(int id)
        {
            var objToDelete = await _unitOfWork.SurveyResponseRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.SurveyResponseRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
