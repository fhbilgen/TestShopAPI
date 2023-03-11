using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExceptionController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static string notanumber = "abc";
        public ExceptionController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<int> ThrowException()
        {
            int i = int.Parse(notanumber);
            return i;
        }

    }
}
