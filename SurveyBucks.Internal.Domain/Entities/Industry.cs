using SurveyBucks.Internal.Domain.Common;
using System.Collections.Generic;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class Industry : ConcurrencyTokenEntity, IAuditable
    {
        public string Name { get; set; }

        public Industry() : base()
        {
        }

        public Industry(string name) : this()
        {
            Name = name;
        }
    }
}