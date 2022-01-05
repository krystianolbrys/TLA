using Microsoft.AspNetCore.Mvc;

namespace TLA.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return Ok(new { Status = "OK - Working" });
        }
    }
}