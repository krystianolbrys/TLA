﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLA.BackEnd.Commands.Requests;
using TLA.BackEnd.Commands.Responses;

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
        public async Task<ActionResult<AddQuizResponse>> AddQuiz(string name) =>
            await _mediator.Send(new AddQuizCommand(name));
    }
}
