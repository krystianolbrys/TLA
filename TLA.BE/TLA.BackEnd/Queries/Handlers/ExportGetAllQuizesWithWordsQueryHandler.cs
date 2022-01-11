using MediatR;
using TLA.BackEnd.Queries.Requests;
using TLA.BackEnd.Queries.Responses;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.BackEnd.Queries.Handlers
{
    internal class ExportGetAllQuizesWithWordsQueryHandler : IRequestHandler<ExportGetAllQuizesWithWordsQuery, ExportAllQuizesWithWordsQueryResponse>
    {
        private readonly IWordRepository _wordsRepository;

        public ExportGetAllQuizesWithWordsQueryHandler(IWordRepository wordsRepository)
        {
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
        }

        public async Task<ExportAllQuizesWithWordsQueryResponse> Handle(ExportGetAllQuizesWithWordsQuery request, CancellationToken cancellationToken)
        {
            var quizesWithWords = await _wordsRepository.GetAllQuizesWithWords();

            var quizesResponse = quizesWithWords.Select(quiz => new QuizResponse
            {
                QuizName = quiz.Name,
                GuidIdentifier = quiz.GuidIdentifier,
                Words = quiz.Words
                    .Select(word => new WordResponse
                    {
                        InputWord = word.InputWord,
                        OutputWord = word.OutputWord,
                        GuidIdentifier = word.GuidIdentifier
                    }).ToList(),
            }).ToList();

            return new ExportAllQuizesWithWordsQueryResponse
            {
                Quizes = quizesResponse
            };
        }
    }
}
