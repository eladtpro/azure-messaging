azure-messaging

1.  [Learn](https://learn.microsoft.com/en-us/)
2.  [Azure](https://learn.microsoft.com/en-us/azure/)
3.  [Messaging services](https://learn.microsoft.com/en-us/azure/messaging-services/)
4.  [Service Bus Messaging](https://learn.microsoft.com/en-us/azure/service-bus-messaging/)

1.  [Learn](https://learn.microsoft.com/en-us/)
2.  [Azure](https://learn.microsoft.com/en-us/azure/)
3.  [Messaging services](https://learn.microsoft.com/en-us/azure/messaging-services/)
4.  [Service Bus Messaging](https://learn.microsoft.com/en-us/azure/service-bus-messaging/)

[Read in English](https://learn.microsoft.com/en-us/azure/service-bus-messaging/compare-messaging-services "Read in English") Add[](https://github.com/MicrosoftDocs/azure-docs/blob/main/articles/service-bus-messaging/compare-messaging-services.md "Edit This Document")

Table of contents [Read in English](https://learn.microsoft.com/en-us/azure/service-bus-messaging/compare-messaging-services "Read in English") Add [Edit](https://github.com/MicrosoftDocs/azure-docs/blob/main/articles/service-bus-messaging/compare-messaging-services.md "Edit This Document") Print

[Twitter](https://twitter.com/intent/tweet?original_referer=https%3A%2F%2Flearn.microsoft.com%2Fen-us%2Fazure%2Fservice-bus-messaging%2Fcompare-messaging-services%3FWT.mc_id%3Dtwitter&text=Today%20I%20completed%20%22Compare%20Azure%20messaging%20services%20-%20Azure%20Service%20Bus%20%7C%20Microsoft%20Learn%22!%20I'm%20so%20proud%20to%20be%20celebrating%20this%20achievement%20and%20hope%20this%20inspires%20you%20to%20start%20your%20own%20%40MicrosoftLearn%20journey!&tw_p=tweetbutton&url=https%3A%2F%2Flearn.microsoft.com%2Fen-us%2Fazure%2Fservice-bus-messaging%2Fcompare-messaging-services%3FWT.mc_id%3Dtwitter) [LinkedIn](https://www.linkedin.com/feed/?shareActive=true&text=Today%20I%20completed%20%22Compare%20Azure%20messaging%20services%20-%20Azure%20Service%20Bus%20%7C%20Microsoft%20Learn%22!%20I'm%20so%20proud%20to%20be%20celebrating%20this%20achievement%20and%20hope%20this%20inspires%20you%20to%20start%20your%20own%20%40MicrosoftLearn%20journey!%0A%0D%0Ahttps%3A%2F%2Flearn.microsoft.com%2Fen-us%2Fazure%2Fservice-bus-messaging%2Fcompare-messaging-services%3FWT.mc_id%3Dlinkedin) [Facebook](https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Flearn.microsoft.com%2Fen-us%2Fazure%2Fservice-bus-messaging%2Fcompare-messaging-services%3FWT.mc_id%3Dfacebook) [Email](mailto:?subject=%5BShared%20Article%5D%20Compare%20Azure%20messaging%20services%20-%20Azure%20Service%20Bus%20%7C%20Microsoft%20Learn&body=Today%20I%20completed%20%22Compare%20Azure%20messaging%20services%20-%20Azure%20Service%20Bus%20%7C%20Microsoft%20Learn%22!%20I'm%20so%20proud%20to%20be%20celebrating%20this%20achievement%20and%20hope%20this%20inspires%20you%20to%20start%20your%20own%20%40MicrosoftLearn%20journey!%0A%0D%0Ahttps%3A%2F%2Flearn.microsoft.com%2Fen-us%2Fazure%2Fservice-bus-messaging%2Fcompare-messaging-services%3FWT.mc_id%3Demail)

Table of contents

Choose between Azure messaging services - Event Grid, Event Hubs, and Service Bus
=================================================================================

*   Article
*   04/29/2023
*   1 contributor

Feedback

In this article
---------------

- [Choose between Azure messaging services - Event Grid, Event Hubs, and Service Bus](#choose-between-azure-messaging-services---event-grid-event-hubs-and-service-bus)
  - [In this article](#in-this-article)
  - [Event vs. message services](#event-vs-message-services)
    - [Event](#event)
    - [Message](#message)
  - [Azure Event Grid](#azure-event-grid)
  - [Azure Event Hubs](#azure-event-hubs)
  - [Azure Service Bus](#azure-service-bus)
  - [Comparison of services](#comparison-of-services)
  - [Use the services together](#use-the-services-together)
  - [Next steps](#next-steps)

Show 3 more

Azure offers three services that assist with delivering events or messages throughout a solution. These services are:

*   Azure Event Grid
*   Azure Event Hubs
*   Azure Service Bus

Although they have some similarities, each service is designed for particular scenarios. This article describes the differences between these services, and helps you understand which one to choose for your application. In many cases, the messaging services are complementary and can be used together.

[](#event-vs-message-services)

Event vs. message services
--------------------------

There's an important distinction between services that deliver an event and services that deliver a message.

[](#event)

### Event

An event is a lightweight notification of a condition or a state change. The publisher of the event has no expectation about how the event is handled. The consumer of the event decides what to do with the notification. Events can be discrete units or part of a series.

Discrete events report state change and are actionable. To take the next step, the consumer only needs to know that something happened. The event data has information about what happened but doesn't have the data that triggered the event. For example, an event notifies consumers that a file was created. It may have general information about the file, but it doesn't have the file itself. Discrete events are ideal for serverless solutions that need to scale.

A series of events reports a condition and are analyzable. The events are time-ordered and interrelated. The consumer needs the sequenced series of events to analyze what happened.

[](#message)

### Message

A message is raw data produced by a service to be consumed or stored elsewhere. The message contains the data that triggered the message pipeline. The publisher of the message has an expectation about how the consumer handles the message. A contract exists between the two sides. For example, the publisher sends a message with the raw data, and expects the consumer to create a file from that data and send a response when the work is done.

[](#azure-event-grid)

Azure Event Grid
----------------

Event Grid is an eventing backplane that enables event-driven, reactive programming. It uses the publish-subscribe model. Publishers emit events, but have no expectation about how the events are handled. Subscribers decide on which events they want to handle.

Event Grid is deeply integrated with Azure services and can be integrated with third-party services. It simplifies event consumption and lowers costs by eliminating the need for constant polling. Event Grid efficiently and reliably routes events from Azure and non-Azure resources. It distributes the events to registered subscriber endpoints. The event message has the information you need to react to changes in services and applications. Event Grid isn't a data pipeline, and doesn't deliver the actual object that was updated.

It has the following characteristics:

*   Dynamically scalable
*   Low cost
*   Serverless
*   At least once delivery of an event

Event Grid is offered in two editions: **Azure Event Grid**, a fully managed PaaS service on Azure, and **Event Grid on Kubernetes with Azure Arc**, which lets you use Event Grid on your Kubernetes cluster wherever that is deployed, on-premises or on the cloud. For more information, see [Azure Event Grid overview](../event-grid/overview) and [Event Grid on Kubernetes with Azure Arc overview](../event-grid/kubernetes/overview).

[](#azure-event-hubs)

Azure Event Hubs
----------------

Azure Event Hubs is a big data streaming platform and event ingestion service. It can receive and process millions of events per second. It facilitates the capture, retention, and replay of telemetry and event stream data. The data can come from many concurrent sources. Event Hubs allows telemetry and event data to be made available to various stream-processing infrastructures and analytics services. It's available either as data streams or bundled event batches. This service provides a single solution that enables rapid data retrieval for real-time processing, and repeated replay of stored raw data. It can capture the streaming data into a file for processing and analysis.

It has the following characteristics:

*   Low latency
*   Can receive and process millions of events per second
*   At least once delivery of an event

For more information, see [Event Hubs overview](../event-hubs/event-hubs-about).

[](#azure-service-bus)

Azure Service Bus
-----------------

Service Bus is a fully managed enterprise message broker with message queues and publish-subscribe topics. The service is intended for enterprise applications that require transactions, ordering, duplicate detection, and instantaneous consistency. Service Bus enables cloud-native applications to provide reliable state transition management for business processes. When handling high-value messages that can't be lost or duplicated, use Azure Service Bus. This service also facilitates highly secure communication across hybrid cloud solutions and can connect existing on-premises systems to cloud solutions.

Service Bus is a brokered messaging system. It stores messages in a "broker" (for example, a queue) until the consuming party is ready to receive the messages. It has the following characteristics:

*   Reliable asynchronous message delivery (enterprise messaging as a service) that requires polling
*   Advanced messaging features like first-in and first-out (FIFO), batching/sessions, transactions, dead-lettering, temporal control, routing and filtering, and duplicate detection
*   At least once delivery of a message
*   Optional ordered delivery of messages

For more information, see [Service Bus overview](service-bus-messaging-overview).

[](#comparison-of-services)

Comparison of services
----------------------

Service

Purpose

Type

When to use

Event Grid

Reactive programming

Event distribution (discrete)

React to status changes

Event Hubs

Big data pipeline

Event streaming (series)

Telemetry and distributed data streaming

Service Bus

High-value enterprise messaging

Message

Order processing and financial transactions

[](#use-the-services-together)

Use the services together
-------------------------

In some cases, you use the services side by side to fulfill distinct roles. For example, an e-commerce site can use Service Bus to process the order, Event Hubs to capture site telemetry, and Event Grid to respond to events like an item was shipped.

In other cases, you link them together to form an event and data pipeline. You use Event Grid to respond to events in the other services. For an example of using Event Grid with Event Hubs to migrate data to Azure Synapse Analytics, see [Stream big data into a Azure Synapse Analytics](../event-grid/event-hubs-integration). The following image shows the workflow for streaming the data.

![Diagram showing how Event Hubs, Service Bus, and Event Grid can be connected together.](media/compare-messaging-services/overview.svg)

[](#next-steps)

Next steps
----------

See the following articles:

*   [Asynchronous messaging options in Azure](/en-us/azure/architecture/guide/technology-choices/messaging)
*   [Events, Data Points, and Messages - Choosing the right Azure messaging service for your data](https://azure.microsoft.com/blog/events-data-points-and-messages-choosing-the-right-azure-messaging-service-for-your-data/).