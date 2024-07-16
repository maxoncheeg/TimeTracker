using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.ResponseExtensions;
using TimeTracker.Domain.CQRS.Enums.Requests;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Data.Handlers.Queries.Projects;

public class GetProjectNamesByDateUpdatedHandler(LocalDbContext context)
    : IRequestHandler<GetProjectNamesByDateUpdatedQuery, IList<ProjectNameResponse>>
{
    public async Task<IList<ProjectNameResponse>> Handle(GetProjectNamesByDateUpdatedQuery request,
        CancellationToken cancellationToken)
    {
        return await (request.OrderType == OrderBy.Ascending
                ? context.Projects.OrderBy(project => project.DateUpdated)
                : context.Projects.OrderByDescending(project => project.DateUpdated))
            .Skip(request.Skip)
            .Take(request.Take)
            .ToProjectNameResponse()
            .ToListAsync(cancellationToken);
    }
}