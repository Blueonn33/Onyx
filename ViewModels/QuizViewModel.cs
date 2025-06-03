namespace Onyx.ViewModels
{
    public class QuizViewModel
    {
        public string Title { get; set; }
        public int TimeLimit { get; set; } // в минути
        public IFormFile? ImageFile { get; set; }
    }
}
