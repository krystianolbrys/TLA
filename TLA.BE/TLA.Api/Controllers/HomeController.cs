using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLA.BackEnd.Commands.Requests;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.Api.Controllers
{
    [Route("infrastructure")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IWordRepository wordsRepository, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("createBasicData")]
        public async Task<ActionResult> CreateBasicData()
        {
            var quiz = await _mediator.Send(new AddQuizCommand("SampleQuiz1"));

            await _mediator.Send(new AddWordCommand("wchłaniać", "absorb", quiz.Id));
            await _mediator.Send(new AddWordCommand("nawiązywać", "referring", quiz.Id));
            await _mediator.Send(new AddWordCommand("zapobiegać", "prevent", quiz.Id));
            await _mediator.Send(new AddWordCommand("nienawidzić", "detest", quiz.Id));
            await _mediator.Send(new AddWordCommand("dostosować", "adjust, suit, adapt", quiz.Id));

            return Ok();
        }
    }
}