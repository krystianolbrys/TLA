using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLA.BackEnd.Queries.Export;
using TLA.BackEnd.QueryHandlersResponses;

namespace TLA.Api.Controllers.External
{
    [Route("external/export")]
    public class ExportController : Controller
    {
        private readonly IMediator _mediator;

        public ExportController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("words")]
        public async Task<ActionResult<AllQuizesWithWordsQueryResponse>> GetWords()
        {
            var message = new GetAllQuizesWithWordsQuery();

            return await _mediator.Send(message);
        }
    }
}
