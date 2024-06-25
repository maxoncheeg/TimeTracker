using TimeTracker.Views;

namespace TimeTracker;

public partial class App : Application
{
    public App(MainPage page)
    {
        InitializeComponent();

        MainPage = page;
    }
}