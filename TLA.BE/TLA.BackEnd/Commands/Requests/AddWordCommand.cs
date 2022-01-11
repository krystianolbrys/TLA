using MediatR;
using TLA.BackEnd.Commands.Responses;

namespace TLA.BackEnd.Commands.Requests
{
    public class AddWordCommand : IRequest<AddWordResponse>
    {
        public AddWordCommand(string inputWord, string outputWord, int quizId)
        {
            InputWord = inputWord;
            OutputWord = outputWord;
            QuizId = quizId;
        }

        public string InputWord { get; } = null!;

        public string OutputWord { get; } = null!;

        public int QuizId { get; }
    }
}
