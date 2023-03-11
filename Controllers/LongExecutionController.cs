using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LongExecutionController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        private static string reqUrl = "https://testshopapi2.azurewebsites.net/api/outerrim/longexecution";
        private static string reqUrl2 = "https://testshopapi2.azurewebsites.net/api/outerrim/randomexecution";

        private readonly ILogger<WeatherForecastController> _logger;
       
        public LongExecutionController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<int> LongExecution() 
        {
            System.Threading.Thread.Sleep(50000);
            return 50000;

        }

        [HttpGet]
        public ActionResult<int> DoubleHop()
        {
            var result = client.GetStringAsync(reqUrl).Result;
            return result;

        }

        [HttpGet]
        public ActionResult<int> ChattyDoubleHop()
        {
            int result = 0;
            for(int i = 0; i!=10;i++)
                result += client.GetStringAsync(reqUrl2).Result;
            return result;

        }

    }
}
