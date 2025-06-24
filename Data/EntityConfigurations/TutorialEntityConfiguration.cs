using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Onyx.Models;

namespace Onyx.Data.EntityConfigurations
{
    public class TutorialEntityConfiguration : IEntityTypeConfiguration<Tutorial>
    {
        public void Configure(EntityTypeBuilder<Tutorial> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
            builder.Property(t => t.ImageData).IsRequired();
            builder.Property(t => t.ImageMimeType).IsRequired().HasMaxLength(100);

            builder.HasMany(t => t.Sections)
                   .WithOne(t => t.Tutorial)
                   .HasForeignKey(t => t.TutorialId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
