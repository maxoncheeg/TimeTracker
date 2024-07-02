using MediatR;

namespace TimeTracker.Domain.CQRS.Queries.Requests;

public record ScrolledRequest<T> : IRequest<IList<T>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 20;
}