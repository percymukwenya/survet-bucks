namespace SurveyBucks.Internal.Application.Models.Response
{
    public class QuestionResponseChoiceModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public int QuestionId { get; set; }
    }
}
