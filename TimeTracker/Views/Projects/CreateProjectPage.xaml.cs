using TimeTracker.ViewModels.Projects;

namespace TimeTracker.Views.Projects;

public partial class CreateProjectPage : ContentPage
{
    public CreateProjectPage(CreateProjectViewModel model)
    {
        InitializeComponent();

        BindingContext = model;

        model.CloseCommandReceived += async () => await Navigation.PopModalAsync(true);
    }
}