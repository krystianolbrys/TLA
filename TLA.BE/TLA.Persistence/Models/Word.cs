namespace TLA.Persistence.Models
{
    public class Word
    {
        public int Id { get; set; }

        public string InputWord { get; set; } = null!;

        public string OutputWord { get; set; } = null!;

        public int QuizId { get; set; }

        public Quiz Quiz { get; set; } = null!;
    }
}
