namespace TimeTracker.Views;

public static class VisualElementExtensions
{
    public static async Task MakeFadeAnimation(this VisualElement @this, uint duration)
    {
        await @this.FadeTo(0.7f, duration);
        await @this.FadeTo(1, duration);
    }
}