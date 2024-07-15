using System.Collections.ObjectModel;
using MediatR;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;
using TimeTracker.ViewModels.Commands;

namespace TimeTracker.ViewModels;

public class UiProjectView(int id, string letters)
{
    public int Id { get; } = id;
    public string Letters { get; } = letters;
}

public class MainViewModel : AbstractViewModel
{
    private readonly IMediator _mediator;

    #region Bindings

    private ObservableCollection<UiProjectView> _projects = [];

    public ObservableCollection<UiProjectView> Projects => _projects;

    #endregion

    #region Commands

    public ParameterCommand OpenProjectCommand => new(OpenProject);

    private void OpenProject(object? parameter)
    {
        if (parameter != null)
        {
            int id = int.Parse(parameter.ToString());
            SendMessage("Открытие проекта", "ID Проекта: " + id);
        }
    }

    #endregion

    public MainViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task UpdateModel()
    {
        var result = await _mediator.Send(new GetProjectsQuery() { Take = 5 });


        _projects = [..result.Select(p => new UiProjectView(p.ProjectId, p.Name[..2]))];
        Notify(nameof(Projects));
    }
}