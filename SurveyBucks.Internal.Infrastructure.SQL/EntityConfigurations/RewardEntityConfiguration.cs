using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class RewardEntityConfiguration : ConcurrencyTokenEntityConfiguration<Reward>, IEntityTypeConfiguration<Reward>
    {
        public void Configure(EntityTypeBuilder<Reward> builder)
        {
            builder.ToTable("Reward", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(150).IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").HasMaxLength(250).IsRequired();
            builder.Property(b => b.Amount).HasColumnName("Amount").HasColumnType("DECIMAL(14,2)").IsRequired();
            builder.Property(b => b.IsGiftReward).HasColumnName("IsGiftReward").IsRequired();
            builder.Property(b => b.RewardTypeId).HasColumnName("RewardTypeId").IsRequired();

            ConfigureConcurrencyToken(builder);

            //Indexes
            builder.HasIndex(b => b.Name, "UX_Reward_Name").IsUnique();

            //One To Many
            builder
                .HasOne(c => c.RewardType)
                .WithMany()
                .HasForeignKey(c => c.RewardTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
