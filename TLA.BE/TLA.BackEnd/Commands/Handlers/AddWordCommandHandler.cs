using MediatR;
using TLA.BackEnd.Commands.Requests;
using TLA.BackEnd.Commands.Responses;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.BackEnd.Commands.Handlers
{
    public class AddWordCommandHandler : IRequestHandler<AddWordCommand, AddWordResponse>
    {
        private readonly IWordRepository _wordRepository;

        public AddWordCommandHandler(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository ?? throw new ArgumentNullException(nameof(wordRepository));
        }

        public async Task<AddWordResponse> Handle(AddWordCommand request, CancellationToken cancellationToken)
        {
            var word = await _wordRepository.AddWordAsync(request.InputWord, request.OutputWord, request.QuizId);

            var response = new AddWordResponse
            {
                Id = word.Id,
                InputWord = word.InputWord,
                OutputWord = word.OutputWord
            };

            return response;
        }
    }
}
