namespace TLA.BackEnd.QueryHandlersResponses
{
    public class AllQuizesWithWordsQueryResponse
    {
        public IReadOnlyCollection<QuizResponse> Quizes { get; set; } = null!;
    }

    public class QuizResponse
    {
        public string QuizName { get; set; } = null!;

        public IReadOnlyCollection<WordResponse> Words { get; set; } = null!;
    }

    public class WordResponse
    {
        public string InputWord { get; set; } = null!;

        public string OutputWord { get; set; } = null!;
    }
}
