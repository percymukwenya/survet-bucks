using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class SurveyStatusEntityConfiguration : ConcurrencyTokenEntityConfiguration<SurveyStatus>, IEntityTypeConfiguration<SurveyStatus>
    {
        public void Configure(EntityTypeBuilder<SurveyStatus> builder)
        {
            builder.ToTable("SurveyStatus", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(75).IsRequired();


        }
    }
}
