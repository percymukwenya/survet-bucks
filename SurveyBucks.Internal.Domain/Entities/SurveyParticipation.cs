using SurveyBucks.Internal.Domain.Common;
using SurveyBucks.Internal.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;

namespace SurveyBucks.Internal.Domain.Entities
{
    public class SurveyParticipation : ConcurrencyTokenEntity, IAuditable
    {
        public DateTime EnrolmentDateTime { get; set; }
        public DateTime StartedAtDateTime { get; set; }
        public DateTime CompletedAtDateTime { get; set; }
        public HashSet<SurveyResponse> SurveyResponses { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public SurveyParticipation() : base()
        {
        }

        public SurveyParticipation(DateTime enrolmentDateTime, DateTime startedAtDateTime,
            DateTime completedAtDateTime, string applicationUserId, int surveyId) : this()
        {
            ArgumentNullException.ThrowIfNull(enrolmentDateTime, nameof(enrolmentDateTime));
            ArgumentNullException.ThrowIfNull(startedAtDateTime, nameof(startedAtDateTime));
            ArgumentNullException.ThrowIfNull(completedAtDateTime, nameof(completedAtDateTime));
            ArgumentNullException.ThrowIfNull(applicationUserId, nameof(applicationUserId));

            EnrolmentDateTime = enrolmentDateTime;
            StartedAtDateTime = startedAtDateTime;
            CompletedAtDateTime = completedAtDateTime;
            ApplicationUserId = applicationUserId;
            SurveyId = surveyId;
        }

        public SurveyParticipation(ApplicationUser applicationUser, Survey survey, DateTime enrolmentDateTime, DateTime startedAtDateTime,
            DateTime completedAtDateTime) : this()
        {
            ArgumentNullException.ThrowIfNull(applicationUser, nameof(applicationUser));
            ArgumentNullException.ThrowIfNull(enrolmentDateTime, nameof(enrolmentDateTime));
            ArgumentNullException.ThrowIfNull(startedAtDateTime, nameof(startedAtDateTime));
            ArgumentNullException.ThrowIfNull(completedAtDateTime, nameof(completedAtDateTime));

            ApplicationUser = applicationUser;
            ApplicationUserId = applicationUser.Id;
            Survey = survey;
            SurveyId = survey.Id;
            EnrolmentDateTime = enrolmentDateTime;
            StartedAtDateTime = startedAtDateTime;
            CompletedAtDateTime = completedAtDateTime;
        }
    }
}
