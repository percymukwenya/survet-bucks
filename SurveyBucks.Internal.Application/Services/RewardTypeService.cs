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
    public class RewardTypeService : IRewardTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RewardTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RewardTypeDetailResponse> GetRewardType(int id)
        {
            var response = await _unitOfWork.RewardTypeRepository.GetByIdAsync(id);

            return _mapper.Map<RewardTypeDetailResponse>(response);
        }

        public async Task<IReadOnlyList<RewardTypeListResponse>> GetRewardTypes()
        {
            var response = await _unitOfWork.RewardTypeRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<RewardTypeListResponse>>(response);
        }

        public async Task AddRewardType(AddRewardTypeRequest request)
        {
            var objToCreate = _mapper.Map<RewardType>(request);

            await _unitOfWork.RewardTypeRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateRewardType(UpdateRewardTypeRequest request)
        {
            var objToUpdate = _mapper.Map<RewardType>(request);

            await _unitOfWork.RewardTypeRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteRewardType(int id)
        {
            var objToDelete = await _unitOfWork.RewardTypeRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.RewardTypeRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
