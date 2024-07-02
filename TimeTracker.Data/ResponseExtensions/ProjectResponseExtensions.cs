using TimeTracker.Data.Entities;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Data.ResponseExtensions;

public static class ProjectResponseExtensions
{
    public static IQueryable<ProjectResponse> ToProjectResponse(this IQueryable<Project> @this) =>
        @this.Select(project => new ProjectResponse()
        {
            ProjectId = project.Id,
            DateCreated = project.DateCreated,
            DateUpdated = project.DateUpdated,
            Name = project.Name,
            Description = project.Description,
            Status = project.Status
        });
}