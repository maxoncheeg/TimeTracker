using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Data.Handlers.Commands.Projects;
using TimeTracker.Data.Handlers.Queries;
using TimeTracker.Domain.CQRS.Commands.Projects;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Shared.Data;

public static class MediatRDataHandlersExtensions
{
    public static IServiceCollection ConfigureMediatRHandlers(this IServiceCollection @this) => //queries
        @this
            //queries
            .AddScoped<IRequestHandler<GetProjectsQuery, IList<ProjectResponse>>, GetProjectsHandler>()
            //commands
            .AddScoped<IRequestHandler<CreateProjectCommand>, CreateProjectHandler>();
}