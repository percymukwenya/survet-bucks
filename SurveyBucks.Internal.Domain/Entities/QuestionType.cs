using SurveyBucks.Internal.Domain.Common;
using System;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class QuestionType : ConcurrencyTokenEntity, IAuditable
    {
        //"Open", "Dropdown",  or "Logical" (the respondent selects yes/no or true/false)
        public string Name { get; set; }

        public QuestionType() : base()
        {
        }

        public QuestionType(string name) : this()
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));

            Name = name;
        }
    }
}