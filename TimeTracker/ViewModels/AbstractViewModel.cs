using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimeTracker.ViewModels.Messagers;

namespace TimeTracker.ViewModels;

public abstract class AbstractViewModel : AbstractMessager, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public event Action? CloseCommandReceived = null;

    public abstract Task UpdateModel();

    protected virtual void Notify([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        Notify(propertyName);
        return true;
    }

    protected virtual void Close()
    {
        CloseCommandReceived?.Invoke();
    }
}