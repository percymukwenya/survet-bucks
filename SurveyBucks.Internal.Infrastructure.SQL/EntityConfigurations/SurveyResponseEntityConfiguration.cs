using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class SurveyResponseEntityConfiguration : ConcurrencyTokenEntityConfiguration<SurveyResponse>, IEntityTypeConfiguration<SurveyResponse>
    {
        public void Configure(EntityTypeBuilder<SurveyResponse> builder)
        {
            builder.ToTable("SurveyResponse", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Answer).HasColumnName("Answer").HasMaxLength(50).IsRequired();        
            builder.Property(b => b.SurveyParticipationId).HasColumnName("SurveyParticipationId").IsRequired();
            builder.Property(b => b.QuestionId).HasColumnName("QuestionId").IsRequired();

            ConfigureConcurrencyToken(builder);

            //One To Many
            builder
                .HasOne(c => c.SurveyParticipation)
                .WithMany(c => c.SurveyResponses)
                .HasForeignKey(c => c.SurveyParticipationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Question)
                .WithMany()
                .HasForeignKey(c => c.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
