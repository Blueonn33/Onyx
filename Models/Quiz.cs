using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onyx.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TimeLimit { get; set; } = 3;// в минути
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public bool Completed { get; set; } = false;
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
