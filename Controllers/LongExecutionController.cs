using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LongExecutionController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        //private static string reqUrl = "https://testshopapi2.azurewebsites.net/api/outerrim/longexecution";
        //private static string reqUrl2 = "https://testshopapi2.azurewebsites.net/api/outerrim/randomexecution";

        
        private static string reqUrl = Environment.GetEnvironmentVariable("TestShopApi2_LongExecution");
        private static string reqUrl2 = Environment.GetEnvironmentVariable("TestShopApi2_RandomExecution");

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
            string res = client.GetStringAsync(reqUrl).Result;
            
            Int32.TryParse(res, out int r);

            return r;

        }

        [HttpGet]
        public ActionResult<int> ChattyDoubleHop()
        {
            int r = 0;
            int result = 0;
            string res;
            for (int i = 0; i != 10; i++)
            {
                res = client.GetStringAsync(reqUrl2).Result;
                Int32.TryParse(res, out r);
                result += r;
            }
            return r;

        }

    }
}
