using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsIsolatedQueue
{
    public class Output
    {
        private readonly ILogger _logger;

        public Output(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Output>();
        }

        [Function("Output")]
        [QueueOutput("alert-queue")]
        public async Task<string> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string message = await new StreamReader(req.Body).ReadToEndAsync();

            return message;
        }
    }
}
