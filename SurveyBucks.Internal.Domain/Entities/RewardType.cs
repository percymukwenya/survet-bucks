using SurveyBucks.Internal.Domain.Common;
using System;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class RewardType : ConcurrencyTokenEntity, IAuditable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public RewardType() : base()
        {
        }

        public RewardType(string name) : this()
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));

            Name = name;
        }
    }
}