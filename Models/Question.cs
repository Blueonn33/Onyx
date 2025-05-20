using System.ComponentModel.DataAnnotations.Schema;

namespace Onyx.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AswerA { get; set; }
        public string AswerB { get; set; }
        public string AswerC { get; set; }
        public string AswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public bool Completed { get; set; } = false;
        public int QuestionNumber { get; set; }
        [ForeignKey(nameof(Quiz))]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
