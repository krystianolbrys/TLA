namespace TLA.Persistence.Models
{
    public class UserResult
    {
        public int Id { get; set; }

        public int WordId { get; set; }

        public int UserId { get; set; }

        public int PostiveAnswers { get; set; }

        public int NegativeAnswers { get; set; }

        public Word Word { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
