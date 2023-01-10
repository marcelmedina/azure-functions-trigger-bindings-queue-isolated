using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsInProcessQueue
{
    public class Trigger
    {
        [FunctionName("Trigger")]
        public void Run([QueueTrigger("alert-queue", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
