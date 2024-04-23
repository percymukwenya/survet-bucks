using SurveyBucks.Internal.Domain.Common;
using System;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class SurveyStatus : ConcurrencyTokenEntity, IAuditable
    {
        public string Name { get; set; }  //"Planned", "Open" and "Closed"
        public string Details { get; set; }

        public SurveyStatus() : base()
        {
        }

        public SurveyStatus(string name) : this()
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));

            Name = name;
        }
    }
}