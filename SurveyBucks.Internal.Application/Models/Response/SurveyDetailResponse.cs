using System;

namespace SurveyBucks.Internal.Application.Models.Response
{
    public class SurveyDetailResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OpeningDateTime { get; set; }
        public DateTime ClosingDateTime { get; set; }
        public int DurationInSeconds { get; set; }
        public int IsPublished { get; set; }
        public string CompanyName { get; set; }
        public string SurveyStatusName { get; set; }
        public string RewardName { get; set; }
    }
}
