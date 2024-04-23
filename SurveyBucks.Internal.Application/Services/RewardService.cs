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
    public class RewardService : IRewardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RewardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RewardDetailResponse> GetReward(int id)
        {
            var response = await _unitOfWork.RewardRepository.GetByIdAsync(id);

            return _mapper.Map<RewardDetailResponse>(response);
        }

        public async Task<IReadOnlyList<RewardListResponse>> GetRewards()
        {
            var response = await _unitOfWork.RewardRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<RewardListResponse>>(response);
        }

        public async Task AddReward(AddRewardRequest request)
        {
            var objToCreate = _mapper.Map<Reward>(request);

            await _unitOfWork.RewardRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateReward(UpdateRewardRequest request)
        {
            var objToUpdate = _mapper.Map<Reward>(request);

            await _unitOfWork.RewardRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteReward(int id)
        {
            var objToDelete = await _unitOfWork.RewardRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.RewardRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
