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
            builder.Property(q => q.AnswerA).IsRequired().HasMaxLength(100);
            builder.Property(q => q.AnswerB).IsRequired().HasMaxLength(100);
            builder.Property(q => q.AnswerC).IsRequired().HasMaxLength(100);
            builder.Property(q => q.AnswerD).IsRequired().HasMaxLength(100);
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