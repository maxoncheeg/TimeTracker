using MediatR;
using TimeTracker.Domain.CQRS.Commands.Repositories;

namespace TimeTracker.Data.Handlers.Commands.Repositories;

public class InitializeRepositoryHandler(LocalDbContext context) : IRequestHandler<InitializeRepositoryCommand>
{
    public Task Handle(InitializeRepositoryCommand request, CancellationToken cancellationToken)
    {
        // the кастыль
        return Task.CompletedTask;
    }
}