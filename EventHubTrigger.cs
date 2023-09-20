using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Microsoft.Function
{
    public static class EventHubTrigger
    {
        [FunctionName("EventHubTrigger")]
        public static async Task Run(
            [EventHubTrigger("hub1", Connection = "EventHubConnectionAppSetting")] EventData[] events, 
            ILogger log)
        {
            var exceptions = new List<Exception>();
            int index = 0;
            foreach (EventData eventData in events)
            {
                log.LogTrace($"[EventHubTrigger] Recieved event {index++}.");
                try
                {
                    // Replace these two lines with your processing logic.
                    log.LogInformation($"[EventHubTrigger] C# Event Hub trigger function processed a message");
                    log.LogInformation($"[EventHubTrigger] Event: {Encoding.UTF8.GetString(eventData.EventBody)}");
                    // Metadata accessed by binding to EventData
                    log.LogInformation($"[EventHubTrigger] SystemProperties={eventData.SystemProperties}");
                    // log.LogInformation($"EnqueuedTimeUtc={eventData.SystemProperties.EnqueuedTimeUtc}");
                    // log.LogInformation($"SequenceNumber={eventData.SystemProperties.SequenceNumber}");
                    // log.LogInformation($"Offset={eventData.SystemProperties.Offset}");
                    // // Metadata accessed by using binding expressions in method parameters
                    // log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
                    // log.LogInformation($"SequenceNumber={sequenceNumber}");
                    // log.LogInformation($"Offset={offset}");


                    await Task.Yield();
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }
}
