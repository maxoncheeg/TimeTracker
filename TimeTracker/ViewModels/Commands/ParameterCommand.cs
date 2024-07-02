using System.Windows.Input;

namespace TimeTracker.ViewModels.Commands;

public class ParameterCommand(Action<object?>? method) : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => method != null;

    public void Execute(object? parameter) => method?.Invoke(parameter);
}