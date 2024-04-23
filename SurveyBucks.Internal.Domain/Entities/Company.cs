using SurveyBucks.Internal.Domain.Common;
using System;
using System.Collections.Generic;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class Company : ConcurrencyTokenEntity, IAuditable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int IndustryId { get; set; }
        public Industry Industry { get; set; }

        public HashSet<Survey> Surveys { get; set; }

        public Company() : base()
        {
            Surveys = new HashSet<Survey>();
        }

        public Company(string name, string description, int industryId) : this()
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(description, nameof(description));

            Name = name;
            Description = description;
            IndustryId = industryId;
        }

        public Company(Industry industry, string name, string description)
        {
            ArgumentNullException.ThrowIfNull(industry, nameof(industry));
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(description, nameof(description));

            Industry = industry;
            IndustryId = Industry.Id;
            Name = name;
            Description = description;
        }
    }
}
