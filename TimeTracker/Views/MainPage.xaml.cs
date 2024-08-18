using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using TimeTracker.ViewModels;
using TimeTracker.ViewModels.Messagers;
using TimeTracker.Views.Projects;

namespace TimeTracker.Views;

public partial class MainPage : ContentPage
{
    private bool _isButtonPushed = false;
    private const uint AnimationDuration = 600u;
    private const uint FadeDuration = 150u;

    private readonly CreateProjectPage _createProjectPage;
    private readonly ProjectListPage _projectListPage;

    private readonly MainViewModel _model;

    public MainPage(MainViewModel model, CreateProjectPage createProjectPage, ProjectListPage projectListPage)
    {
        InitializeComponent();

        BindingContext = model;
        _model = model;
        model.MessageReceived += ModelOnMessageReceived;

        _createProjectPage = createProjectPage;
        _projectListPage = projectListPage;

        Loaded += OnLoaded;
        this.Appearing += OnAppearing;
    }

    private async void OnAppearing(object? sender, EventArgs e)
    {
        OnMenuGridRightSwiped(this, null);
        await _model.UpdateModel();
    }


    private async void ModelOnMessageReceived(object? sender, MessageEventArgs e)
    {
        await DisplayAlert(e.Title, e.Message, "OK");
    }

    private async void OnLoaded(object? sender, EventArgs e)
    {
        await _model.UpdateModel();
    }

    private void OnMenuGridRightSwiped(object? sender, SwipedEventArgs? e)
    {
        MainGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicOut);
        MainGrid.RotateYTo(0, AnimationDuration, Easing.CubicOut);
        MainGrid.ScaleTo(1, AnimationDuration, Easing.CubicOut);
    }

    private void OnMainGridLeftSwiped(object? sender, SwipedEventArgs e)
    {
        MainGrid.TranslateTo(-Width * 0.3, Height * 0.3, AnimationDuration, Easing.CubicOut);
        MainGrid.RotateYTo(10, AnimationDuration, Easing.CubicOut);
        MainGrid.ScaleTo(0.9, AnimationDuration, Easing.CubicOut);
    }

    private async void OnProjectClicked(object? sender, EventArgs e)
    {
        if (_isButtonPushed) return;
        _isButtonPushed = true;
        
        await DisplayAlert("x", "omg", "x");
        
        
        _isButtonPushed = false;
    }


    private async void OnCreateProjectTapped(object? sender, TappedEventArgs e)
    {
        //(sender as VisualElement)?.MakeFadeAnimation(FadeDuration);
        if (_isButtonPushed) return;
        _isButtonPushed = true;
        
        await Navigation.PushModalAsync(_createProjectPage, true);

        _isButtonPushed = false;
    }

    private async void OpenProjectListPage(object? sender, TappedEventArgs e)
    {
        if (_isButtonPushed) return;
        _isButtonPushed = true;
        
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        string text = "Загрузка проектов...";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        var toast = Toast.Make(text, duration, fontSize);

        await toast.Show(cancellationTokenSource.Token);

        await Navigation.PushModalAsync(_projectListPage, true);
        _isButtonPushed = false;
    }
}