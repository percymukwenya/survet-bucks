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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<QuestionListResponse>> GetQuestions()
        {
            var response = await _unitOfWork.QuestionRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<QuestionListResponse>>(response);
        }

        public async Task<QuestionDetailResponse> GetQuestion(int id)
        {
            var response = await GetQuestion(id);

            return _mapper.Map<QuestionDetailResponse>(response);
        }

        public async Task AddQuestion(AddQuestionRequest request)
        {
            var objToCreate = _mapper.Map<Question>(request);

            await _unitOfWork.QuestionRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateQuestion(UpdateQuestionRequest request)
        {
            var objToUpdate = _mapper.Map<Question>(request);

            await _unitOfWork.QuestionRepository.UpdateAsync(objToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteQuestion(int id)
        {
            var objToDelete = await _unitOfWork.QuestionRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.QuestionRepository.DeleteAsync(objToDelete);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
