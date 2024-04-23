using System;

namespace SurveyBucks.Internal.Application.Models.Request
{
    public class AddSurveyRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OpeningDateTime { get; set; }
        public DateTime ClosingDateTime { get; set; }
        public int DurationInSeconds { get; set; }
        public int IsPublished { get; set; }
        public int CompanyId { get; set; }
        public int SurveyStatusId { get; set; }
        public int RewardId { get; set; }
    }
}
