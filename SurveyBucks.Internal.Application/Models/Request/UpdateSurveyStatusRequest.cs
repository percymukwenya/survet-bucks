namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateSurveyStatusRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
