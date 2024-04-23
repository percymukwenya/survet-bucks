using System;

namespace SurveyBucks.Internal.Application.Models.Request
{
    public class AddSurveyParticipationRequest
    {
        public DateTime EnrolmentDateTime { get; set; }
        public DateTime StartedAtDateTime { get; set; }
        public DateTime CompletedAtDateTime { get; set; }
        public string ApplicationUserId { get; set; }
        public int SurveyId { get; set; }
    }
}
