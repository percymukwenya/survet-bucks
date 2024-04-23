namespace SurveyBucks.Internal.Application.Models.Response
{
    public class SurveyResponseDetailResponse
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int SurveyParticipationId { get; set; }
        public string Question { get; set; }
    }
}
