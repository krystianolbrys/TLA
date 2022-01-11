namespace TLA.BackEnd.Commands.Responses
{
    public class AddWordResponse
    {
        public int Id { get; set; }

        public string InputWord { get; set; } = null!;

        public string OutputWord { get; set; } = null!;
    }
}
