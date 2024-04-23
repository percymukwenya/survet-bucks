namespace SurveyBucks.Internal.Application.Models.Response
{
    public class QuestionListResponse
    {
        public string Text { get; set; }
        public bool IsMandatory { get; set; }
        public int Order { get; set; }
        public string SurveyName { get; set; }
        public int QuestionTypeName { get; set; }
    }
}
