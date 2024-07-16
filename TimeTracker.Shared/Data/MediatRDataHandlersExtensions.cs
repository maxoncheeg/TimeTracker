using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Data;
using TimeTracker.Data.Handlers.Commands.Projects;
using TimeTracker.Data.Handlers.Commands.Repositories;
using TimeTracker.Data.Handlers.Queries;
using TimeTracker.Data.Handlers.Queries.Projects;
using TimeTracker.Domain.CQRS.Commands.Projects;
using TimeTracker.Domain.CQRS.Commands.Repositories;
using TimeTracker.Domain.CQRS.Queries.Projects;
using TimeTracker.Domain.CQRS.Responses.Projects;

namespace TimeTracker.Shared.Data;

public static class MediatRDataHandlersExtensions
{
    public static IServiceCollection ConfigureMediatRHandlers(this IServiceCollection @this) => //queries
        @this
            //queries
            .AddScoped<IRequestHandler<GetProjectsQuery, IList<ProjectResponse>>, GetProjectsHandler>()
            .AddScoped<IRequestHandler<GetProjectNamesByDateUpdatedQuery, IList<ProjectNameResponse>>, GetProjectNamesByDateUpdatedHandler>()
            //commands
            .AddScoped<IRequestHandler<CreateProjectCommand>, CreateProjectHandler>()
            .AddScoped<IRequestHandler<InitializeRepositoryCommand>, InitializeRepositoryHandler>();

    public static IServiceCollection AddDatabase(this IServiceCollection @this, string connectionString) =>
        @this.AddTransient<LocalDbContext>(_ => new LocalDbContext(connectionString));
}