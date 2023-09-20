using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Microsoft.Function;
public class Publisher
{
    [FunctionName("Publisher")]
    public void Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        [EventHub("hub1", Connection = "EventHubConnectionAppSetting")] IAsyncCollector<EventData> outputEvents,
        ILogger log)
    {
        log.LogInformation("[Publisher] C# HTTP Publisher trigger function processed a request.");
        string qcount = req.Query["count"];
        int count = int.Parse(qcount);
        log.LogInformation($"[Publisher] Publishing {count} events.");

        int index = 0;
        foreach (EventData eventData in EventProducer.GenerateEvents(count))
        {
            outputEvents.AddAsync(eventData);
            log.LogTrace($"[Publisher] Published event {index++}.");
        }
    }
}

