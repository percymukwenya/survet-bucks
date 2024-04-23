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
    public class SurveyStatusService : ISurveyStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SurveyStatusDetailResponse> GetSurveyStatus(int id)
        {
            var response = await _unitOfWork.SurveyStatusRepository.GetByIdAsync(id);

            return _mapper.Map<SurveyStatusDetailResponse>(response);
        }

        public async Task<IReadOnlyList<SurveyStatusListResponse>> GetSurveyStatuses()
        {
            var response = await _unitOfWork.SurveyStatusRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<SurveyStatusListResponse>>(response);
        }

        public async Task AddSurveyStatus(AddSurveyStatusRequest request)
        {
            var objToCreate = _mapper.Map<SurveyStatus>(request);

            await _unitOfWork.SurveyStatusRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateSurveyStatus(UpdateSurveyStatusRequest request)
        {
            var objToUpdate = _mapper.Map<SurveyStatus>(request);

            await _unitOfWork.SurveyStatusRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSurveyStatus(int id)
        {
            var objToDelete = await _unitOfWork.SurveyStatusRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.SurveyStatusRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
