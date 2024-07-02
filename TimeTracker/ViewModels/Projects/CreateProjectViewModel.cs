using MediatR;
using TimeTracker.Domain.CQRS.Commands.Projects;
using TimeTracker.ViewModels.Commands;

namespace TimeTracker.ViewModels.Projects;

public class CreateProjectViewModel(IMediator mediator) : AbstractViewModel
{
    #region Bindings

    private string _projectName = string.Empty;
    private string _projectDescription = string.Empty;

    public string ProjectName
    {
        get => _projectName;
        set => SetField(ref _projectName, value);
    }
    
    public string ProjectDescription
    {
        get => _projectDescription;
        set => SetField(ref _projectDescription, value);
    }

    #endregion

    #region Commands

    public DefaultCommand CreateProjectCommand => new(CreateProject);

    private async void CreateProject(object? o, EventArgs eventArgs)
    {
        await mediator.Send(new CreateProjectCommand()
        {
            Name = ProjectName,
            Description = ProjectDescription
        });

        Close();
    }
    
    #endregion
    
    public override async Task UpdateModel()
    {
        Notify(nameof(ProjectName));
        Notify(nameof(ProjectDescription));
    }
}