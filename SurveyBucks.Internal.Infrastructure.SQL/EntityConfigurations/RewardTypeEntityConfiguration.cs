using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class RewardTypeEntityConfiguration : ConcurrencyTokenEntityConfiguration<RewardType>, IEntityTypeConfiguration<RewardType>
    {
        public void Configure(EntityTypeBuilder<RewardType> builder)
        {
            builder.ToTable("RewardType", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(250).IsRequired();

            ConfigureConcurrencyToken(builder);

            //Indexes
            builder.HasIndex(b => b.Name, "UX_RewardType_Name").IsUnique();
        }
    }
}
