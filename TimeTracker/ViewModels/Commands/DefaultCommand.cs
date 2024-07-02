using System.Windows.Input;

namespace TimeTracker.ViewModels.Commands;

public class DefaultCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public DefaultCommand(EventHandler method) => CanExecuteChanged += method;

    public bool CanExecute(object? parameter) => CanExecuteChanged != null;

    public void Execute(object? parameter) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}