using TimeTracker.ViewModels.Messagers;
using TimeTracker.ViewModels.Projects;

namespace TimeTracker.Views.Projects;

public partial class CreateProjectPage : ContentPage
{
    private bool _isButtonPushed = false;
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
        if (_isButtonPushed) return;
        _isButtonPushed = true;
        
        NameEntry.IsEnabled = false;
        DescriptionEditor.IsEnabled = false;
        
        await Navigation.PopModalAsync(true);
        
        NameEntry.IsEnabled = true;
        DescriptionEditor.IsEnabled = true;

        _isButtonPushed = false;
    }

    private async void MessagerOnMessageReceived(object? sender, MessageEventArgs e)
    {
        await DisplayAlert(e.Title, e.Message, "OK");
    }
}