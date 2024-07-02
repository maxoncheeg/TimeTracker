using MediatR;
using TimeTracker.Data.Entities;
using TimeTracker.Domain.CQRS.Commands.Projects;
using Task = System.Threading.Tasks.Task;

namespace TimeTracker.Data.Handlers.Commands.Projects;

public class CreateProjectHandler(LocalDbContext context) : IRequestHandler<CreateProjectCommand>
{
    public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        Project project = new Project()
        {
            Name = request.Name,
            Description = request.Description,
            DateCreated = DateTime.UtcNow,
            DateUpdated = DateTime.UtcNow
        };

        context.Add(project);

        await context.SaveChangesAsync(cancellationToken);
    }
}