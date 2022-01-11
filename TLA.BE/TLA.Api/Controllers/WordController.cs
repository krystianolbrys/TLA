using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLA.BackEnd.Commands.Requests;
using TLA.BackEnd.Commands.Responses;

namespace TLA.Api.Controllers
{
    [Route("word")]
    public class WordController : Controller
    {
        private readonly IMediator _mediator;

        public WordController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<AddWordResponse>> AddWord(string inputWord, string outputWord, int quizId) =>
            await _mediator.Send(new AddWordCommand(inputWord, outputWord, quizId));
    }
}
