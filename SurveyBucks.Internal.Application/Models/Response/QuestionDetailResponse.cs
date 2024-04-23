using System.Collections.Generic;

namespace SurveyBucks.Internal.Application.Models.Response
{
    public class QuestionDetailResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsMandatory { get; set; }
        public int Order { get; set; }
        public string SurveyName { get; set; }
        public int QuestionTypeName { get; set; }

        public List<QuestionResponseChoiceModel> QuestionResponseChoices { get; set; }
    }
}
