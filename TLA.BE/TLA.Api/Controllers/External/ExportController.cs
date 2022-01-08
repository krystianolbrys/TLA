using Microsoft.AspNetCore.Mvc;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.Api.Controllers.External
{
    [Route("external/export")]
    public class ExportController : Controller
    {
        private readonly IWordsRepository _wordsRepository;

        public ExportController(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
        }

        [HttpGet]
        [Route("words")]
        public async Task<ActionResult> GetWords()
        {
            var words = await _wordsRepository.GetAllWithQuizGroup();

            var wordDtos = words.Select(word => new WordExportDto
            {
                InputWord = word.InputWord,
                OutputWord = word.OutputWord,
                QuizName = word.Quiz.Name
            }).ToList();

            var result = new WordsExportDto
            {
                Words = wordDtos
            };

            return Ok(result);
        }
    }

    public class WordsExportDto
    {
        public IReadOnlyCollection<WordExportDto> Words { get; set; } = null!;
    }

    public class WordExportDto
    {
        public string InputWord { get; set; } = null!;

        public string OutputWord { get; set; } = null!;

        public string QuizName { get; set; } = null!;
    }
}
