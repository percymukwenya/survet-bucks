namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateQuestionTypeRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
