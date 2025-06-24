using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Onyx.Models;

namespace Onyx.Data.EntityConfigurations
{
    public class SectionItemEntityConfiguration : IEntityTypeConfiguration<SectionItem>
    {
        public void Configure(EntityTypeBuilder<SectionItem> builder)
        {
            builder.HasKey(si => si.Id);
            builder.Property(si => si.Title).IsRequired().HasMaxLength(200);
            builder.Property(si => si.Content).IsRequired().HasMaxLength(1000);
            builder.Property(si => si.SectionId).IsRequired();

            builder.HasOne(si => si.Section)
                   .WithMany(s => s.SectionItems)
                   .HasForeignKey(si => si.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
