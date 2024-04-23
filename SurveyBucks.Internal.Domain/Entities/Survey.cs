using SurveyBucks.Internal.Domain.Common;
using System;
using System.Collections.Generic;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class Survey : ConcurrencyTokenEntity, IAuditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OpeningDateTime { get; set; }
        public DateTime ClosingDateTime { get; set; }
        public int DurationInSeconds { get; set; }
        public int IsPublished { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int SurveyStatusId { get; set; }
        public SurveyStatus SurveyStatus { get; set; }

        public int RewardId { get; set; }
        public Reward Reward { get; set; }

        public HashSet<SurveyParticipation> SurveyParticipations { get; set; }
        public HashSet<Question> Questions { get; set; }

        public Survey() : base()
        {
            SurveyParticipations = new HashSet<SurveyParticipation>();
            Questions = new HashSet<Question>();
        }

        public Survey(string name, string description, DateTime openingDateTime, DateTime closingDateTime,
            int durationInSeconds, int isPublished, int companyId, int surveyStatusId, int rewardId) : this()
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(description, nameof(description));
            ArgumentNullException.ThrowIfNull(openingDateTime, nameof(openingDateTime));
            ArgumentNullException.ThrowIfNull(closingDateTime, nameof(closingDateTime));

            Name = name;
            Description = description;
            OpeningDateTime = openingDateTime;
            ClosingDateTime = closingDateTime;
            DurationInSeconds = durationInSeconds;
            IsPublished = isPublished;
            CompanyId = companyId;
            SurveyStatusId = surveyStatusId;
            RewardId = rewardId;
        }

        public Survey(Company company, SurveyStatus surveyStatus, Reward reward, string name, string description,
            DateTime openingDateTime, DateTime closingDateTime,
            int durationInSeconds, int isPublished) : this()
        {
            ArgumentNullException.ThrowIfNull(company, nameof(company));
            ArgumentNullException.ThrowIfNull(surveyStatus, nameof(surveyStatus));
            ArgumentNullException.ThrowIfNull(reward, nameof(reward));

            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(description, nameof(description));
            ArgumentNullException.ThrowIfNull(openingDateTime, nameof(openingDateTime));
            ArgumentNullException.ThrowIfNull(closingDateTime, nameof(closingDateTime));

            CompanyId = company.Id;
            SurveyStatusId = surveyStatus.Id;
            RewardId = reward.Id;

            Name = name;
            Description = description;
            OpeningDateTime = openingDateTime;
            ClosingDateTime = closingDateTime;
            DurationInSeconds = durationInSeconds;
            IsPublished = isPublished;
        }
    }
}
