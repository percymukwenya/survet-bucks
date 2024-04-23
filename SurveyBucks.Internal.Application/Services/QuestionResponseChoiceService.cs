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
    public class QuestionResponseChoiceService : IQuestionResponseChoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionResponseChoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<QuestionResponseChoiceListResponse>> GetQuestionResponseChoicesByQuestionId(int questionId)
        {
            var questionResponseChoices = await _unitOfWork.QuestionResponseChoiceRepository.GetAllAsync(x => x.QuestionId == questionId, includeProperties: "Question");

            return _mapper.Map<IReadOnlyList<QuestionResponseChoiceListResponse>>(questionResponseChoices);
        }

        public async Task AddQuestionResponseChoice(AddQuestionResponseChoiceRequest request)
        {
            var objToCreate = _mapper.Map<QuestionResponseChoice>(request);

            await _unitOfWork.QuestionResponseChoiceRepository.CreateAsync(objToCreate);

            await _unitOfWork.SaveChangesAsync();
        }   

        public async Task UpdateQuestionResponseChoice(UpdateQuestionResponseChoiceRequest request)
        {
            var objectToUpdate = _mapper.Map<QuestionResponseChoice>(request);

            await _unitOfWork.QuestionResponseChoiceRepository.UpdateAsync(objectToUpdate);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteQuestionResponseChoice(int id)
        {
            var objToDelete = await _unitOfWork.QuestionResponseChoiceRepository.GetByIdAsync(id);

            if (objToDelete != null)
            {
                await _unitOfWork.QuestionResponseChoiceRepository.DeleteAsync(objToDelete);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
