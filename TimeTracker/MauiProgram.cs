﻿using System.Reflection;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TimeTracker.Shared.Data;
using TimeTracker.Shared.Services.Naming;
using TimeTracker.ViewModels;
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
            .AddTransient<MainViewModel>()
            .AddTransient<CreateProjectViewModel>()
            .AddTransient<ProjectListViewModel>();

        #endregion

        #region Services

        builder.Services
            .AddScoped<INameAbbreviationService, NameAbbreviationService>();

        #endregion

        builder
            .UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("SoyuzGrotesk-Bold.otf", "SoyuzGrotesk");
                fonts.AddFont("sangha.ttf", "Sangha");
                fonts.AddFont("Cruinn Regular.ttf", "CruinRegular");
                fonts.AddFont("Cruinn Light.ttf", "CruinLight");
                fonts.AddFont("Cruinn Medium.ttf", "CruinMedium");
                fonts.AddFont("Cruinn Bold.ttf", "CruinBold");
            });

        builder.Services
            .AddDatabase(Path.Combine(FileSystem.AppDataDirectory, "time_tracker.db3"))
            .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .ConfigureMediatRHandlers();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}