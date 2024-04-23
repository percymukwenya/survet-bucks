namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateQuestionResponseChoiceRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public int QuestionId { get; set; }
    }
}
