using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onyx.Models;

namespace Onyx.Data.EntityConfigurations
{
    public class QuizEntityConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Title).IsRequired().HasMaxLength(100);
            builder.Property(q => q.TimeLimit).IsRequired();
            builder.Property(q => q.ImageData).IsRequired();
            builder.Property(q => q.ImageMimeType).IsRequired().HasMaxLength(100);
            builder.Property(q => q.UserId).IsRequired();
            builder.Property(q => q.Completed);

            builder.HasMany(q => q.Questions)
                   .WithOne(q => q.Quiz)
                   .HasForeignKey(q => q.QuizId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
