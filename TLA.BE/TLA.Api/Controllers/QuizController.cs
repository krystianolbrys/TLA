using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLA.BackEnd.Commands.Requests;

namespace TLA.Api.Controllers
{
    [Route("quiz")]
    public class QuizController : Controller
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<string>> AddQuiz(string name)
        {
            var command = new AddQuizCommand(name);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
