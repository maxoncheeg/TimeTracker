using System.Reflection;
using Microsoft.Extensions.Logging;
using TimeTracker.Shared.Data;
using TimeTracker.ViewModels.Projects;
using TimeTracker.Views;
using TimeTracker.Views.Projects;

namespace TimeTracker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        #region Views

        builder.Services
            .AddTransient<MainPage>()
            .AddTransient<CreateProjectPage>()
            .AddTransient<ProjectListPage>();

        // viewModels
        builder.Services
            .AddTransient<CreateProjectViewModel>()
            .AddTransient<ProjectListViewModel>();

        #endregion

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("SoyuzGrotesk-Bold.otf", "SoyuzGrotesk");
            });

        builder.Services.AddTransient<IDatabaseInitializer>(_ =>
            new LocalDatabaseInitializer(Path.Combine(FileSystem.AppDataDirectory, "time_tracker.db3")));

        builder.Services
            .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .ConfigureMediatRHandlers();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}