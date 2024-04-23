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
    public class SurveyParticipationService : ISurveyParticipationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyParticipationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SurveyParticipationDetailResponse> GetSurveyParticipation(int id)
        {
            var response = await _unitOfWork.SurveyParticipationRepository.GetByIdAsync(id);

            return _mapper.Map<SurveyParticipationDetailResponse>(response);
        }

        public async Task<IReadOnlyList<SurveyParticipationListResponse>> GetSurveyParticipations()
        {
            var response = await _unitOfWork.SurveyParticipationRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<SurveyParticipationListResponse>>(response);
        }

        public async Task AddSurveyParticipation(AddSurveyParticipationRequest request)
        {
            var objToCreate = _mapper.Map<SurveyParticipation>(request);

            await _unitOfWork.SurveyParticipationRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }      

        public async Task UpdateSurveyParticipation(UpdateSurveyParticipationRequest request)
        {
            var objToUpdate = _mapper.Map<SurveyParticipation>(request);

            await _unitOfWork.SurveyParticipationRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSurveyParticipation(int id)
        {
            var objToDelete = await _unitOfWork.SurveyParticipationRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.SurveyParticipationRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
