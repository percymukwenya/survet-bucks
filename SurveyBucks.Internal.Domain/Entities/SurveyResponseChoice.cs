using SurveyBucks.Internal.Domain.Common;
using System;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class SurveyResponseChoice : ConcurrencyTokenEntity, IAuditable
    {
        public string Text { get; set; }
        public int Order { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public SurveyResponseChoice() : base()
        {
        }

        public SurveyResponseChoice(string text, int order, int questionId) : this()
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            Text = text;
            Order = order;
            QuestionId = questionId;
        }

        public SurveyResponseChoice(Question question, string text, int order) : this()
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            Question = question;
            QuestionId = question.Id;
            Text = text;
            Order = order;            
        }
    }
}
