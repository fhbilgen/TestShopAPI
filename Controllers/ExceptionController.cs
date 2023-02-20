using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static string notanumber = "abc";
        public ExceptionController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetException")]
        public ActionResult<int> Get()
        {
            int i = int.Parse(notanumber);
            return i;
        }

    }
}
