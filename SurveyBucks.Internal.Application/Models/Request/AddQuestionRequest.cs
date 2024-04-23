namespace SurveyBucks.Internal.Application.Models.Request
{
    public class AddQuestionRequest
    {
        public string Text { get; set; }
        public bool IsMandatory { get; set; }
        public int Order { get; set; }
        public int SurveyId { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
