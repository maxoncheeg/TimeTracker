using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Views;

public partial class MainPage : ContentPage
{
    private const uint AnimationDuration = 600u;

    public MainPage()
    {
        InitializeComponent();
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
        await DisplayAlert("This project cannot be opened",
            $"Project color: {(sender as Button).BackgroundColor.ToString()}", "Sad");
    }
}