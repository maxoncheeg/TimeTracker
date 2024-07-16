using TimeTracker.Domain.CQRS.Enums.Requests;
using TimeTracker.Domain.CQRS.Queries.Requests;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Domain.CQRS.Queries.Projects;

public record GetProjectNamesByDateUpdatedQuery : ScrolledRequest<ProjectNameResponse>
{
    public OrderBy OrderType { get; set; } = OrderBy.Descending;
}