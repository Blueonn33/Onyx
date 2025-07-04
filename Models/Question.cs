﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Onyx.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public bool Completed { get; set; } = false;
        public int QuestionNumber { get; set; }
        [ForeignKey(nameof(Quiz))]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
