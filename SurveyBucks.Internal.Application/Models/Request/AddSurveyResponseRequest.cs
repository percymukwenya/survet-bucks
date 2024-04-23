using SurveyBucks.Internal.Domain.Entities;

namespace SurveyBucks.Internal.Application.Models.Request
{
    public class AddSurveyResponseRequest
    {
        public string Answer { get; set; }

        public int SurveyParticipationId { get; set; }

        public int QuestionId { get; set; }
    }
}
