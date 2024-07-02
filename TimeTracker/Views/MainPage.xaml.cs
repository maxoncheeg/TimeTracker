using TimeTracker.Views.Projects;

namespace TimeTracker.Views;

public partial class MainPage : ContentPage
{
    private const uint AnimationDuration = 600u;
    private const uint FadeDuration = 150u;

    private readonly CreateProjectPage _createProjectPage;
    private readonly ProjectListPage _projectListPage;
    
    public MainPage(CreateProjectPage createProjectPage, ProjectListPage projectListPage)
    {
        InitializeComponent();

        _createProjectPage = createProjectPage;
        _projectListPage = projectListPage;

        ProjectsListView.ItemsSource = new List<object>() {1,2,3};
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
    }
}