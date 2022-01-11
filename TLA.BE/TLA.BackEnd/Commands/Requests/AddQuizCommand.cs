using MediatR;
using TLA.BackEnd.Commands.Responses;

namespace TLA.BackEnd.Commands.Requests
{
    public class AddQuizCommand : IRequest<AddQuizResponse>
    {
        public AddQuizCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
