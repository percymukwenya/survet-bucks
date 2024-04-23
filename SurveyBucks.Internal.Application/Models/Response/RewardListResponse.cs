namespace SurveyBucks.Internal.Application.Models.Response
{
    public class RewardListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsGiftReward { get; set; }
        public string RewardTypeName { get; set; }
    }
}
