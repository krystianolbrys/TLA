using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLA.BackEnd.Queries.Requests;
using TLA.BackEnd.Queries.Responses;

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
        public async Task<ActionResult<ExportAllQuizesWithWordsQueryResponse>> GetWords() =>
            await _mediator.Send(new ExportGetAllQuizesWithWordsQuery());
    }
}
