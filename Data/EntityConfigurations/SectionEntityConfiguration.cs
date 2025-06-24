using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Onyx.Models;

namespace Onyx.Data.EntityConfigurations
{
    public class SectionEntityConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(100);
            builder.Property(s => s.TutorialId).IsRequired();

            builder.HasOne(s => s.Tutorial)
                   .WithMany(t => t.Sections)
                   .HasForeignKey(s => s.TutorialId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SectionItems)
                   .WithOne(si => si.Section)
                   .HasForeignKey(si => si.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
