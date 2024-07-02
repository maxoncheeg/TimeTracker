using MediatR;

namespace TimeTracker.Domain.CQRS.Commands.Projects;

public record CreateProjectCommand : IRequest
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}