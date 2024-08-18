using System.Collections.ObjectModel;
using MediatR;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;
using TimeTracker.Shared.Services.Naming;
using TimeTracker.ViewModels.Commands;

namespace TimeTracker.ViewModels;

public record UiProjectView(int Id, string Letters);

public class MainViewModel : AbstractViewModel
{
    private readonly IMediator _mediator;
    private readonly INameAbbreviationService _nameAbbreviationService;

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

    public MainViewModel(IMediator mediator, INameAbbreviationService nameAbbreviationService)
    {
        _mediator = mediator;
        _nameAbbreviationService = nameAbbreviationService;
    }

    public override async Task UpdateModel()
    {
        var result = await _mediator.Send(new GetProjectNamesByDateUpdatedQuery() { Take = 5 });
        
        _projects =
        [
            ..result.Select(p => new UiProjectView(
                p.ProjectId, 
                _nameAbbreviationService.GetAbbreviation(p.Name)))
        ];
        
        Notify(nameof(Projects)); 
    }
}