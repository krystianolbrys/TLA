using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLA.BackEnd;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWordsRepository _wordsRepository;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IWordsRepository wordsRepository, IMediator mediator)
        {
            _logger = logger;
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("index")]
        public async Task<ActionResult> Index()
        {

            var asdasd = await _mediator.Send(new Ping());

            var data = await _wordsRepository.GetAll();

            if (!data.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    await _wordsRepository.AddSampleWord();
                }
            }

            return Ok(new { Status = asdasd, Data = data });
        }
    }
}