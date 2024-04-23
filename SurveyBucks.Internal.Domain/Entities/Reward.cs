using SurveyBucks.Internal.Domain.Common;
using System;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class Reward : ConcurrencyTokenEntity, IAuditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsGiftReward { get; set; }

        public int RewardTypeId { get; set; }
        public RewardType RewardType { get; set; }

        public Reward(): base()
        {            
        }

        public Reward(string name, string description, decimal amount, bool isGiftReward, int rewardTypeId) : this()
        {
            Name = name;
            Description = description;
            Amount = amount;
            IsGiftReward = isGiftReward;
            RewardTypeId = rewardTypeId;
        }

        public Reward(RewardType rewardType, string name, string description, decimal amount, bool isGiftReward) : this()
        {
            ArgumentNullException.ThrowIfNull(rewardType, nameof(rewardType));
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(description, nameof(description));
            ArgumentNullException.ThrowIfNull(isGiftReward, nameof(isGiftReward));

            RewardType = rewardType;
            RewardTypeId = rewardType.Id;

            Name = name;
            Description = description;
            Amount = amount;
            IsGiftReward = isGiftReward;
        }
    }
}