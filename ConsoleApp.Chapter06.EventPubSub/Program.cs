// Event Subscription memory Leak Demo
var publisher = new EventPublisher();
var subscriber = new EventSubscriber();

// Subscriber attaches to the event
subscriber.Subscribe(publisher);

for (int i = 0; i < 15; i++)
{
    // Simulate event triggering
    publisher.TriggerEvent();

    // Optionally unsubscribe
    // Uncomment the following line to test memory management with unsubscribing
    // subscriber.Unsubscribe(publisher);
}

// Keep the console window open
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

