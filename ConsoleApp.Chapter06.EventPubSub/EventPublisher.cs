public class EventPublisher
{
    public event EventHandler MyEvent;

    public void TriggerEvent()
    {
        MyEvent?.Invoke(this, EventArgs.Empty);
    }
}

