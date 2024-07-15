using TimeTracker.ViewModels;
using TimeTracker.ViewModels.Messagers;
using TimeTracker.Views.Projects;

namespace TimeTracker.Views;

public partial class MainPage : ContentPage
{
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
    }

    private async void ModelOnMessageReceived(object? sender, MessageEventArgs e)
    {
        await DisplayAlert(e.Title, e.Message, "OK");
    }

    private async void OnLoaded(object? sender, EventArgs e)
    {
        await _model.UpdateModel();
    }

    private void OnMenuGridRightSwiped(object? sender, SwipedEventArgs e)
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
        await DisplayAlert("x", "omg", "x");
    }
    
    
    private async void OnCreateProjectTapped(object? sender, TappedEventArgs e)
    {
        (sender as VisualElement)?.MakeFadeAnimation(FadeDuration);

         await Navigation.PushModalAsync(_createProjectPage, true);
    }
    
    private async void OnSecondTapped(object? sender, TappedEventArgs e)
    {
        (sender as VisualElement)?.MakeFadeAnimation(FadeDuration);

         await Navigation.PushModalAsync(_projectListPage, true);
         //
         // Task.Factory.StartNew(()=>
         // {
         //     Navigation.PushModalAsync(_projectListPage, true);
         // });
    }
}