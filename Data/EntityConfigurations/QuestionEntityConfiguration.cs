using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onyx.Models;

namespace Onyx.Data.EntityConfigurations
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Title).IsRequired().HasMaxLength(100);
            builder.Property(q => q.AswerA).IsRequired().HasMaxLength(100);
            builder.Property(q => q.AswerB).IsRequired().HasMaxLength(100);
            builder.Property(q => q.AswerC).IsRequired().HasMaxLength(100);
            builder.Property(q => q.AswerD).IsRequired().HasMaxLength(100);
            builder.Property(q => q.CorrectAnswer).IsRequired().HasMaxLength(1);
            builder.Property(q => q.Completed);
            builder.Property(q => q.QuestionNumber).IsRequired();

            builder.HasOne(q => q.Quiz)
                   .WithMany(q => q.Questions)
                   .HasForeignKey(q => q.QuizId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}