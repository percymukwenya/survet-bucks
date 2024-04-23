namespace SurveyBucks.Internal.Application.Models.Response
{
    public class SurveyResponseListResponse
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int SurveyParticipationId { get; set; }
        public string Question { get; set; }
    }
}
