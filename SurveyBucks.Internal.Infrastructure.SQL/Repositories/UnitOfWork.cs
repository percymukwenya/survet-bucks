using SurveyBucks.Internal.Domain.Contracts;
using SurveyBucks.Internal.Infrastructure.SQL.Contexts;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Infrastructure.SQL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private ICompanyRepository _companyRepository;
        private IIndustryRepository _industryRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionResponseChoiceRepository _questionResponseChoiceRepository;
        private IQuestionTypeRepository _questionTypeRepository;
        private IRewardRepository _rewardRepository;
        private IRewardTypeRepository _rewardTypeRepository;
        private ISurveyParticipationRepository _surveyParticipationRepository;
        private ISurveyRepository _surveyRepository;        
        private ISurveyResponseRepository _surveyResponseRepository;
        private ISurveyStatusRepository _surveyStatusRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICompanyRepository CompanyRepository => 
            _companyRepository ?? new CompanyRepository(_context);

        public IIndustryRepository IndustryRepository => 
            _industryRepository ?? new IndustryRepository(_context);

        public IQuestionRepository QuestionRepository => 
            _questionRepository ?? new QuestionRepository(_context);

        public IQuestionResponseChoiceRepository QuestionResponseChoiceRepository =>
            _questionResponseChoiceRepository ?? new QuestionResponseChoiceRepository(_context);

        public IQuestionTypeRepository QuestionTypeRepository => 
            _questionTypeRepository ?? new QuestionTypeRepository(_context);

        public IRewardRepository RewardRepository => 
            _rewardRepository ?? new RewardRepository(_context);

        public IRewardTypeRepository RewardTypeRepository => 
            _rewardTypeRepository ?? new RewardTypeRepository(_context);

        public ISurveyParticipationRepository SurveyParticipationRepository => 
            _surveyParticipationRepository ?? new SurveyParticipationRepository(_context);

        public ISurveyRepository SurveyRepository => 
            _surveyRepository ?? new SurveyRepository(_context);        

        public ISurveyResponseRepository SurveyResponseRepository => 
            _surveyResponseRepository ?? new SurveyResponseRepository(_context);

        public ISurveyStatusRepository SurveyStatusRepository => 
           _surveyStatusRepository ?? new SurveyStatusRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
