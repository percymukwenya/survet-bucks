using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    internal class SurveyParticipationEntityConfiguration : ConcurrencyTokenEntityConfiguration<SurveyParticipation>, IEntityTypeConfiguration<SurveyParticipation>
    {
        public void Configure(EntityTypeBuilder<SurveyParticipation> builder)
        {
            builder.ToTable("SurveyParticipation", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.EnrolmentDateTime).HasColumnName("EnrolmentDateTime").IsRequired();
            builder.Property(b => b.StartedAtDateTime).HasColumnName("StartedAtDateTime").IsRequired(false);
            builder.Property(b => b.CompletedAtDateTime).HasColumnName("CompletedAtDateTime").IsRequired(false);
            builder.Property(b => b.ApplicationUserId).HasColumnName("ApplicationUserId").HasMaxLength(36).IsRequired();
            builder.Property(b => b.SurveyId).HasColumnName("SurveyId").IsRequired();

            ConfigureConcurrencyToken(builder);

            //One To Many
            builder
                .HasOne(c => c.ApplicationUser)
                .WithMany()
                .HasForeignKey(c => c.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Survey)
                .WithMany(c => c.SurveyParticipations)
                .HasForeignKey(c => c.SurveyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
