using MediatR;
using TLA.BackEnd.Queries.Export;
using TLA.BackEnd.QueryHandlersResponses;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.BackEnd.QueryHandlers.Export
{
    public class GetAllQuizesWithWordsQueryHandler : IRequestHandler<GetAllQuizesWithWordsQuery, AllQuizesWithWordsQueryResponse>
    {
        private readonly IWordsRepository _wordsRepository;

        public GetAllQuizesWithWordsQueryHandler(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
        }

        public async Task<AllQuizesWithWordsQueryResponse> Handle(GetAllQuizesWithWordsQuery request, CancellationToken cancellationToken)
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

            return new AllQuizesWithWordsQueryResponse
            {
                Quizes = quizesResponse
            };
        }
    }
}
