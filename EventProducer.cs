using System;
using System.Collections.Generic;
using System.Text;
using Azure.Messaging.EventHubs;

namespace Microsoft.Function;

public static class EventProducer {
    public static IEnumerable<EventData> GenerateEvents(int numberOfEvents)
    {
        for (int i = 0; i < numberOfEvents; i++)
            yield return GenerateEvent(i);
    }
    public static EventData GenerateEvent(int id)
    {
        string template = 
        $@"{{
            'topic': '/subscriptions/subscription-id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount',
            'subject': '/blobServices/default/containers/oc2d2817345i200097container/blobs/oc2d2817345i20002296blob',
            'eventType': 'Microsoft.Storage.BlobCreated',
            'eventTime': '{DateTime.UtcNow}',
            'id': '{id}',
            'data': {{
                'api': 'PutBlockList',
                'clientRequestId': '6d79dbfb-0e37-4fc4-981f-442c9ca65760',
                'requestId': '831e1650-001e-001b-66ab-eeb76e000000',
                'eTag': '0x8D4BCC2E4835CD0',
                'contentType': 'application/octet-stream',
                'contentLength': 524288,
                'blobType': 'BlockBlob',
                'url': 'https://oc2d2817345i60006.blob.core.windows.net/oc2d2817345i200097container/oc2d2817345i20002296blob',
                'sequencer': '00000000000004420000000000028963',
                'storageDiagnostics': {{
                    'batchId': 'b68529f3-68cd-4744-baa4-3c0498ec19f0'
                }}
            }},
            'dataVersion': '',
            'metadataVersion': '1'
        }}";
        byte[] eventDataBytes = Encoding.UTF8.GetBytes(template);
        return new EventData(eventDataBytes);
        // return new EventData(template);
    }
}