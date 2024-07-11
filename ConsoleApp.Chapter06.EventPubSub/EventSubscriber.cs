public class EventSubscriber
{
    public void Subscribe(EventPublisher publisher)
    {
        publisher.MyEvent += HandleEvent;
    }

    public void Unsubscribe(EventPublisher publisher)
    {
        publisher.MyEvent -= HandleEvent;
    }

    private void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event handled.");
    }
}
