using MediatR;

namespace TLA.BackEnd
{
    public class Ping : IRequest<string> { }

    internal class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}