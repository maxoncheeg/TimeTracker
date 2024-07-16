using TimeTracker.ViewModels.Messagers;
using TimeTracker.ViewModels.Projects;

namespace TimeTracker.Views.Projects;

public partial class CreateProjectPage : ContentPage
{
    private readonly IMessager _messager;
    
    public CreateProjectPage(CreateProjectViewModel model)
    {
        InitializeComponent();

        BindingContext = model;
        _messager = model;
        
        _messager.MessageReceived += MessagerOnMessageReceived;

        model.CloseCommandReceived += ModelOnCloseCommandReceived;
    }

    private async void ModelOnCloseCommandReceived()
    {
        NameEntry.IsEnabled = false;
        DescriptionEditor.IsEnabled = false;
        await Navigation.PopModalAsync(true);
        NameEntry.IsEnabled = true;
        DescriptionEditor.IsEnabled = true;
    }

    private async void MessagerOnMessageReceived(object? sender, MessageEventArgs e)
    {
        await DisplayAlert(e.Title, e.Message, "OK");
    }
}