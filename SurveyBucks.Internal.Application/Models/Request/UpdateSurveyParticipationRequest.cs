using System;

namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateSurveyParticipationRequest
    {
        public int Id { get; set; }
        public DateTime EnrolmentDateTime { get; set; }
        public DateTime StartedAtDateTime { get; set; }
        public DateTime CompletedAtDateTime { get; set; }
        public string ApplicationUserId { get; set; }
        public int SurveyId { get; set; }
    }
}
