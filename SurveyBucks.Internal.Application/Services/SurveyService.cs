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
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SurveyDetailResponse> GetSurvey(int id)
        {
            var response = await _unitOfWork.SurveyRepository.GetByIdAsync(id);

            return _mapper.Map<SurveyDetailResponse>(response);
        }

        public async Task<IReadOnlyList<SurveyListResponse>> GetSurveys()
        {
            var response = await _unitOfWork.SurveyRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<SurveyListResponse>>(response);
        }

        public async Task AddSurvey(AddSurveyRequest request)
        {
            var objToCreate = _mapper.Map<Survey>(request);

            await _unitOfWork.SurveyRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateSurvey(UpdateSurveyRequest request)
        {
            var objToUpdate = _mapper.Map<Survey>(request);

            await _unitOfWork.SurveyRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSurvey(int id)
        {
            var objToDelete = await _unitOfWork.SurveyRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.SurveyRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
