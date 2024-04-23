using System;

namespace SurveyBucks.Internal.Application.Models.Response
{
    public class SurveyParticipationListResponse
    {
        public int Id { get; set; }
        public DateTime EnrolmentDateTime { get; set; }
        public DateTime StartedAtDateTime { get; set; }
        public DateTime CompletedAtDateTime { get; set; }
        public string ApplicationUserId { get; set; }
        public string SurveyName { get; set; }
    }
}
