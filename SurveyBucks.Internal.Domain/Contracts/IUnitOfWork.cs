using System;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IIndustryRepository IndustryRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IQuestionResponseChoiceRepository QuestionResponseChoiceRepository { get; }
        IQuestionTypeRepository QuestionTypeRepository { get; }
        IRewardRepository RewardRepository { get; }
        IRewardTypeRepository RewardTypeRepository { get; }
        ISurveyParticipationRepository SurveyParticipationRepository { get; }
        ISurveyRepository SurveyRepository { get; }        
        ISurveyResponseRepository SurveyResponseRepository { get; }
        ISurveyStatusRepository SurveyStatusRepository { get; }

        Task SaveChangesAsync();
    }
}
