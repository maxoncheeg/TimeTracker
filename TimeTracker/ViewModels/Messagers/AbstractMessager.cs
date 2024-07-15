namespace TimeTracker.ViewModels.Messagers;

public abstract class AbstractMessager : IMessager
{
    public event EventHandler<MessageEventArgs>? MessageReceived;

    protected void SendMessage(string title, string message)
        => MessageReceived?.Invoke(this, new(title, message));
}