namespace TimeTracker.ViewModels.Messagers;

public class MessageEventArgs : EventArgs
{
    public string Title { get; }
    public string Message { get; }

    public MessageEventArgs(string title, string message)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Empty title", nameof(title));
        
        if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Empty message", nameof(message));

        Title = title;
        Message = message;
    }
}