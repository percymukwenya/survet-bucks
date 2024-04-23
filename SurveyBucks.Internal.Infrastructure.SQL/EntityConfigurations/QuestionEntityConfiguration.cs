using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class QuestionEntityConfiguration : ConcurrencyTokenEntityConfiguration<Question>, IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Text).HasColumnName("Text").HasMaxLength(150).IsRequired();
            builder.Property(b => b.IsMandatory).HasColumnName("IsMandatory").HasDefaultValue(false).IsRequired();
            builder.Property(b => b.QuestionTypeId).HasColumnName("QuestionTypeId").IsRequired();

            ConfigureConcurrencyToken(builder);

            //One To Many
            builder
                .HasOne(c => c.QuestionType)
                .WithMany()
                .HasForeignKey(c => c.QuestionTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Survey)
                .WithMany()
                .HasForeignKey(c => c.SurveyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
