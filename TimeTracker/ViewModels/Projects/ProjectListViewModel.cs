using System.Collections.ObjectModel;
using MediatR;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;
using TimeTracker.Shared.Services.Naming;
using TimeTracker.ViewModels.Commands;

namespace TimeTracker.ViewModels.Projects;

public record UiProjectListObjectView(int Id, string Name, string Letters, string Description);

public class ProjectListViewModel : AbstractViewModel
{
    private readonly IMediator _mediator;
    private readonly INameAbbreviationService _nameAbbreviationService;

    private IList<ProjectResponse> _projectList = [];

    public event Action<object>? ObjectReceived;

    #region Bindings

    private ObservableCollection<UiProjectListObjectView> _projects = [];

    public ObservableCollection<UiProjectListObjectView> Projects => _projects;

    #endregion

    #region Commands

    public ParameterCommand OpenProjectCommand => new(OpenProject);

    private void OpenProject(object? parameter)
    {
        if (parameter != null)
        {
            int id = int.Parse(parameter.ToString());
            ObjectReceived?.Invoke(_projectList.FirstOrDefault(p => p.ProjectId == id).Name);
        }
    }

    #endregion

    public ProjectListViewModel(IMediator mediator, INameAbbreviationService nameAbbreviationService)
    {
        _mediator = mediator;
        _nameAbbreviationService = nameAbbreviationService;
    }

    public override async Task UpdateModel()
    {
        _projectList = await _mediator.Send(new GetProjectsQuery());

        _projects =
        [
            .._projectList.Select(p => new UiProjectListObjectView(
                p.ProjectId, p.Name,
                _nameAbbreviationService.GetAbbreviation(p.Name),
                p.Description))
        ];
        Notify(nameof(Projects));
    }
}