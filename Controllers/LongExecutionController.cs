using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LongExecutionController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
       
        public LongExecutionController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetLongExecution")]
        public ActionResult<int> Get() 
        {
            System.Threading.Thread.Sleep(50000);
            return 50000;

        }

    }
}
