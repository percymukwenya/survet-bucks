using SurveyBucks.Internal.Domain.Common;
using System;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class QuestionResponseChoice : ConcurrencyTokenEntity, IAuditable
    {
        public string Text { get; set; }
        public int Order { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public QuestionResponseChoice() : base()
        {
        }

        public QuestionResponseChoice(string text, int order, int questionId) : this()
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            Text = text;
            Order = order;
            QuestionId = questionId;
        }

        public QuestionResponseChoice(Question question, string text, int order) : this()
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            Question = question;
            QuestionId = question.Id;
            Text = text;
            Order = order;            
        }
    }
}
