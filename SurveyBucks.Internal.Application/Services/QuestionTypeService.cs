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
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<QuestionTypeDetailResponse> GetQuestionType(int id)
        {
            var response = await _unitOfWork.QuestionTypeRepository.GetByIdAsync(id);

            return _mapper.Map<QuestionTypeDetailResponse>(response);
        }

        public async Task<IReadOnlyList<QuestionTypeListResponse>> GetQuestionTypes()
        {
            var response = await _unitOfWork.QuestionTypeRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<QuestionTypeListResponse>>(response);
        }

        public async Task AddQuestionType(AddQuestionTypeRequest request)
        {
            var objToCreate = _mapper.Map<QuestionType>(request);

            await _unitOfWork.QuestionTypeRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }              

        public async Task UpdateQuestionType(UpdateQuestionTypeRequest request)
        {
            var objToUpdate = _mapper.Map<QuestionType>(request);

            await _unitOfWork.QuestionTypeRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteQuestionType(int id)
        {
            var objToDelete = await _unitOfWork.QuestionTypeRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.QuestionTypeRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
