using TimeTracker.Domain.CQRS.Queries.Requests;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Domain.CQRS.Queries.Projects;

public record GetProjectsQuery : ScrolledRequest<ProjectResponse>
{
    public string Search { get; set; } = string.Empty;
}