using MediatR;
using TimeTracker.Domain.CQRS.Commands.Repositories;
using TimeTracker.Views;

namespace TimeTracker;

public partial class App : Application
{
    public App(MainPage page, IMediator mediator)
    {
        mediator.Send(new InitializeRepositoryCommand());
        InitializeComponent();

        MainPage = page;
    }
}