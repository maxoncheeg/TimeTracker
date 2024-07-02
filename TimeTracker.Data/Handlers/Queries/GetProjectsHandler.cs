using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.ResponseExtensions;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Data.Handlers.Queries;

public class GetProjectsHandler(LocalDbContext context) : IRequestHandler<GetProjectsQuery, IList<ProjectResponse>>
{
    public async Task<IList<ProjectResponse>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var query = context.Projects.Where(project =>
                project.Name.Contains(request.Search) || project.Description.Contains(request.Search))
            .Skip(request.Skip)
            .Take(request.Take)
            .ToProjectResponse();

        return await query.ToListAsync(cancellationToken);
    }
}