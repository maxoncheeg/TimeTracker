using MediatR;
using TimeTracker.Data.Handlers.Commands.Projects;
using TimeTracker.Data.Handlers.Queries;
using TimeTracker.Domain.CQRS.Commands.Projects;
using TimeTracker.Domain.CQRS.Enums;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Extensions;

public static class ServicesExtensions
{
    public static void AddMediatRHandlers(this IServiceCollection @this)
    {
        //queries
        @this
            .AddScoped<IRequestHandler<GetProjectsQuery, IList<ProjectResponse>>, GetProjectsHandler>();
        
        //commands
        @this 
            .AddScoped<IRequestHandler<CreateProjectCommand>, CreateProjectHandler>();

    }
}