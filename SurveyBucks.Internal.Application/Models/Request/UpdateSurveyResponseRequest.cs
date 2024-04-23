namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateSurveyResponseRequest
    {
        public string Answer { get; set; }

        public int SurveyParticipationId { get; set; }

        public int QuestionId { get; set; }
    }
}
