using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Weather
    {
        private readonly ILogger _logger;

        public Weather(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Weather>();
        }

        [Function("Weather")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            response.WriteString(
                """
                [
                  {
                    "date": "2022-01-06",
                    "temperatureC": 1,
                    "summary": "Freezing"
                  },
                  {
                    "date": "2022-01-07",
                    "temperatureC": 14,
                    "summary": "Bracing"
                  },
                  {
                    "date": "2022-01-08",
                    "temperatureC": -13,
                    "summary": "Freezing"
                  },
                  {
                    "date": "2022-01-09",
                    "temperatureC": -16,
                    "summary": "Balmy"
                  },
                  {
                    "date": "2022-01-10",
                    "temperatureC": -2,
                    "summary": "Chilly"
                  }
                ]
                """);

            return response;
        }
    }
}
