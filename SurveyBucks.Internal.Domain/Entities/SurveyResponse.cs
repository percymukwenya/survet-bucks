using SurveyBucks.Internal.Domain.Common;
using SurveyBucks.Internal.Infrastructure.Identity.Models;
using System;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class SurveyResponse : ConcurrencyTokenEntity, IAuditable
    {
        public string Answer { get; set; }

        public int SurveyParticipationId { get; set; }
        public SurveyParticipation SurveyParticipation { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public SurveyResponse() : base()
        {            
        }

        public SurveyResponse(string answer, int surveyParticipationId, int questionId) : this()
        {
            ArgumentNullException.ThrowIfNull(answer, nameof(answer));

            Answer = answer;
            SurveyParticipationId = surveyParticipationId;
            QuestionId = questionId;
        }

        public SurveyResponse(SurveyParticipation surveyParticipation, Question question,string answer) : this()
        {
            ArgumentNullException.ThrowIfNull(surveyParticipation, nameof(surveyParticipation));
            ArgumentNullException.ThrowIfNull(question, nameof(question));
            ArgumentNullException.ThrowIfNull(answer, nameof(answer));

            SurveyParticipation = surveyParticipation;
            SurveyParticipationId = surveyParticipation.Id;
            Question = question;
            QuestionId = question.Id;
            Answer = answer;            
        }
    }
}
