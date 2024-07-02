using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.ViewModels.Projects;

namespace TimeTracker.Views.Projects;

public partial class ProjectListPage : ContentPage
{
    private ProjectListViewModel _model;
    
    public ProjectListPage(ProjectListViewModel model)
    {
        InitializeComponent();
        
        BindingContext = model;
        _model = model;
        model.ObjectReceived += async (obj) => await DisplayAlert("MESSAGE", obj.ToString(), "okie-dokie");
        
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object? sender, EventArgs e)
    {
        await _model.UpdateModel();
    }

    private async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        //await DisplayAlert("MESSAGE", "hello", "okie-dokie");
    }
}