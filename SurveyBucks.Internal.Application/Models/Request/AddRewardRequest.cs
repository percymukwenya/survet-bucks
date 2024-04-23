namespace SurveyBucks.Internal.Application.Models.Request
{
    public class AddRewardRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsGiftReward { get; set; }
        public int RewardTypeId { get; set; }
    }
}
