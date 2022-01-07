namespace TLA.Persistence.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Word> Words { get; set; } = new List<Word>();
    }
}
