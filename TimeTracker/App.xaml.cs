using MediatR;
using TimeTracker.Domain.CQRS.Commands.Repositories;
using TimeTracker.Views;

namespace TimeTracker;

public partial class App : Application
{
    private readonly IMediator _mediator;
    
    public App(MainPage page, IMediator mediator)
    {
        InitializeComponent();

        _mediator = mediator;
        MainPage = page;
    }

    protected override async void OnStart()
    {
        base.OnStart();
        await _mediator.Send(new InitializeRepositoryCommand());
    }
}