using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("index")]
        public async Task<ActionResult> Index()
        {
            
            var data = await _wordsRepository.GetAll();

            if (!data.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    await _wordsRepository.AddSampleWord();
                }
            }

            return Ok(new { Status = "OK - Working", Data = data });
        }
    }
}