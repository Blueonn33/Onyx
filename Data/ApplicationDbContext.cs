using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onyx.Data.EntityConfigurations;
using Onyx.Models;

namespace Onyx.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionItem> SectionItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new QuizEntityConfiguration());
            builder.ApplyConfiguration(new QuestionEntityConfiguration());
            builder.ApplyConfiguration(new TutorialEntityConfiguration());
            builder.ApplyConfiguration(new SectionEntityConfiguration());
            builder.ApplyConfiguration(new SectionItemEntityConfiguration());
        }
    }
}
