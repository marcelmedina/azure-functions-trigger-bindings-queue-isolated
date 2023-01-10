using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsInProcessQueue
{
    public static class Output
    {
        [FunctionName("Output")]
        [return: Queue("alert-queue")]
        public static async Task<string> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string message = await new StreamReader(req.Body).ReadToEndAsync();

            return message;
        }
    }
}
