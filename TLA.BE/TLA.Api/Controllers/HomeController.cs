﻿using Microsoft.AspNetCore.Mvc;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWordsRepository _wordsRepository;

        public HomeController(ILogger<HomeController> logger, IWordsRepository wordsRepository)
        {
            _logger = logger;
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
        }

        public async Task<ActionResult> Index()
        {
            await _wordsRepository.AddSampleWord();
            var data = await _wordsRepository.GetAll();

            return Ok(new { Status = "OK - Working", Data = data });
        }
    }
}