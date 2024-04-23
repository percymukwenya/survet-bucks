namespace SurveyBucks.Internal.Application.Models.Request
{
    public class AddQuestionResponseChoiceRequest
    {
        public string Text { get; set; }
        public int Order { get; set; }
        public int QuestionId { get; set; }
    }
}
