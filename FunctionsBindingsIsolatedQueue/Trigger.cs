using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsIsolatedQueue
{
    public class Trigger
    {
        private readonly ILogger _logger;

        public Trigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Trigger>();
        }

        [Function("Trigger")]
        public void Run([QueueTrigger("alert-queue", Connection = "AzureWebJobsStorage")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
