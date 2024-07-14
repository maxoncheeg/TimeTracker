using TimeTracker.Shared.Data;
using TimeTracker.Views;

namespace TimeTracker;

public partial class App : Application
{
    public App(MainPage page, IDatabaseInitializer initializer)
    {
        InitializeComponent();

        MainPage = page;
    }
}