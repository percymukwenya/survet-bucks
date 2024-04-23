using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Application.Services.Contract
{
    public interface IQuestionTypeService
    {
        Task<IReadOnlyList<QuestionTypeListResponse>> GetQuestionTypes();
        Task<QuestionTypeDetailResponse> GetQuestionType(int id);
        Task AddQuestionType(AddQuestionTypeRequest request);
        Task UpdateQuestionType(UpdateQuestionTypeRequest request);
        Task DeleteQuestionType(int id);
    }
}
