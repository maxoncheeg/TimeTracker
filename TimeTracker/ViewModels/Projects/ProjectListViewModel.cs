using System.Collections.ObjectModel;
using MediatR;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;
using TimeTracker.ViewModels.Commands;

namespace TimeTracker.ViewModels.Projects;

public class ProjectListViewModel : AbstractViewModel
{
    private IMediator _mediator;

    public event Action<object>? ObjectReceived;
    
    #region Bindings

    private ObservableCollection<ProjectResponse> _projects = [];

    public ObservableCollection<ProjectResponse> Projects => _projects;

    #endregion

    #region Commands

    public ParameterCommand OpenProjectCommand => new(OpenProject);

    private void OpenProject(object? parameter)
    {
        if (parameter != null)
        {
            int id = int.Parse(parameter.ToString());
            ObjectReceived?.Invoke(_projects.FirstOrDefault(p => p.ProjectId == id).Name);
        }
    }

    #endregion

    public ProjectListViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public override async Task UpdateModel()
    {
        var result = await _mediator.Send(new GetProjectsQuery());
        
        _projects = [..result];
        Notify(nameof(Projects));
    }
}