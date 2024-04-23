using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class QuestionResponseChoiceEntityConfiguration : ConcurrencyTokenEntityConfiguration<QuestionResponseChoice>, IEntityTypeConfiguration<QuestionResponseChoice>
    {
        public void Configure(EntityTypeBuilder<QuestionResponseChoice> builder)
        {
            builder.ToTable("QuestionResponseChoice", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Text).HasColumnName("Text").HasMaxLength(50).IsRequired();
            builder.Property(b => b.Order).HasColumnName("Order").IsRequired();
            builder.Property(b => b.QuestionId).HasColumnName("QuestionId").IsRequired();

            ConfigureConcurrencyToken(builder);

            //Indexes
            builder.HasIndex(b => new { b.QuestionId, b.Text }, "IX_QuestionResponseChoice_QuestionId_Text").IsUnique();

            //One To Many
            builder
                .HasOne(c => c.Question)
                .WithMany()
                .HasForeignKey(c => c.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
