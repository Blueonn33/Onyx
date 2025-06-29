﻿namespace Onyx.ViewModels
{
    public class QuestionViewModel
    {
        public string Title { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public int QuestionNumber { get; set; }
        public int QuizId { get; set; }
    }
}
