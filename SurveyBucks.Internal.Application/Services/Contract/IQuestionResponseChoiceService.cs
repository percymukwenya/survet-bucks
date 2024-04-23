using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface IQuestionResponseChoiceService
    {
        Task<IReadOnlyList<QuestionResponseChoiceListResponse>> GetQuestionResponseChoicesByQuestionId(int questionId);
        Task AddQuestionResponseChoice(AddQuestionResponseChoiceRequest request);
        Task UpdateQuestionResponseChoice(UpdateQuestionResponseChoiceRequest request);
        Task DeleteQuestionResponseChoice(int id);
    }
}
