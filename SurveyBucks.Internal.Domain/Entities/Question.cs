using SurveyBucks.Internal.Domain.Common;
using System;
using System.Collections.Generic;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class Question : ConcurrencyTokenEntity, IAuditable
    {
        public string Text { get; set; }
        public bool IsMandatory { get; set; }
        public int Order { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public HashSet<QuestionResponseChoice> ResponseChoices { get; set; }

        public Question() : base()
        {
            ResponseChoices = new HashSet<QuestionResponseChoice>();
        }

        public Question(string text, bool isMandatory, int order, int questionTypeId) : this()
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));
            ArgumentNullException.ThrowIfNull(isMandatory, nameof(isMandatory));

            Text = text;
            IsMandatory = isMandatory;
            Order = order;
            QuestionTypeId = questionTypeId;
        }

        public Question(Survey survey, QuestionType questionType, string text, bool isMandatory, int order) : this()
        {
            ArgumentNullException.ThrowIfNull(survey, nameof(survey));
            ArgumentNullException.ThrowIfNull(questionType, nameof(questionType));
            ArgumentNullException.ThrowIfNull(text, nameof(text));
            ArgumentNullException.ThrowIfNull(isMandatory, nameof(isMandatory));

            Survey = survey;
            SurveyId = survey.Id;
            QuestionType = questionType;
            QuestionTypeId = questionType.Id;

            Text = text;
            IsMandatory = isMandatory;
            Order = order;
        }
    }
}
