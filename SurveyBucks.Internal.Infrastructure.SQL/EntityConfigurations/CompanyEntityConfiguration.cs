using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyBucks.Internal.Domain.Entities;
using SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations.Shared;

namespace SurveyBucks.Internal.Infrastructure.SQL.EntityConfigurations
{
    public class CompanyEntityConfiguration : ConcurrencyTokenEntityConfiguration<Company>, IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "SurveyBucks");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(150).IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").HasMaxLength(250).IsRequired(false);
            builder.Property(b => b.IndustryId).HasColumnName("IndustryId").IsRequired();

            ConfigureConcurrencyToken(builder);

            //Indexes
            builder.HasIndex(b => b.Name, "UX_Company_Name").IsUnique();

            //One To Many
            builder
                .HasOne(c => c.Industry)
                .WithMany()
                .HasForeignKey(c => c.IndustryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
