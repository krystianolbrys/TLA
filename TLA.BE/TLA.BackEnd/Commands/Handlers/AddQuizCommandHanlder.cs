using MediatR;
using TLA.BackEnd.Commands.Requests;
using TLA.BackEnd.Commands.Responses;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.BackEnd.Commands.Handlers
{
    public class AddQuizCommandHanlder : IRequestHandler<AddQuizCommand, AddQuizResponse>
    {
        private readonly IQuizRepository _quizRepository;

        public AddQuizCommandHanlder(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository ?? throw new ArgumentNullException(nameof(quizRepository));
        }

        public async Task<AddQuizResponse> Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.AddQuizAsync(request.Name);

            var response = new AddQuizResponse
            {
                Id = quiz.Id,
                Name = quiz.Name
            };

            return response;
        }
    }
}
