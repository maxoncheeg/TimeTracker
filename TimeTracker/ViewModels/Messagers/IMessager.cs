namespace TimeTracker.ViewModels.Messagers;

public interface IMessager
{
    public event EventHandler<MessageEventArgs>? MessageReceived;
}