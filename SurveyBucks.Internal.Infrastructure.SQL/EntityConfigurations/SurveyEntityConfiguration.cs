using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;
using System;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class SurveyEntityConfiguration : ConcurrencyTokenEntityConfiguration<Survey>, IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Survey", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(150).IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").HasMaxLength(250).IsRequired();
            builder.Property(b => b.OpeningDateTime).HasColumnName("OpeningDateTime").IsRequired(false);
            builder.Property(b => b.ClosingDateTime).HasColumnName("ClosingDateTime").IsRequired(false);
            builder.Property(b => b.DurationInSeconds).HasColumnName("DurationInSeconds").IsRequired();
            builder.Property(b => b.IsPublished).HasColumnName("IsPublished").IsRequired();
            builder.Property(b => b.CompanyId).HasColumnName("CompanyId").IsRequired();
            builder.Property(b => b.SurveyStatusId).HasColumnName("SurveyStatusId").IsRequired();
            builder.Property(b => b.RewardId).HasColumnName("RewardId").IsRequired();

            ConfigureConcurrencyToken(builder);

            //Indexes
            builder.HasIndex(b => b.Name, "UX_Survey_Name").IsUnique();

            //One To Many
            builder
                .HasOne(c => c.Company)
                .WithMany(c => c.Surveys)
                .HasForeignKey(c => c.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.SurveyStatus)
                .WithMany()
                .HasForeignKey(c => c.SurveyStatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Reward)
                .WithMany()
                .HasForeignKey(c => c.RewardId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
