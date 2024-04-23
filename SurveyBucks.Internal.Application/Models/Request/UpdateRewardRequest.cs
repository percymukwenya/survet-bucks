namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateRewardRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsGiftReward { get; set; }
        public int RewardTypeId { get; set; }
    }
}
