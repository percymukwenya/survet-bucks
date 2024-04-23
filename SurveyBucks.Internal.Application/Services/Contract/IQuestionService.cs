using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface IQuestionService
    {
        Task<IReadOnlyList<QuestionListResponse>> GetQuestions();
        Task<QuestionDetailResponse> GetQuestion(int id);
        Task AddQuestion(AddQuestionRequest request);
        Task UpdateQuestion(UpdateQuestionRequest request);
        Task DeleteQuestion(int id);
    }
}
