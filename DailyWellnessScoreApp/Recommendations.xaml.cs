namespace DailyWellnessScoreApp;
public partial class Recommendations : ContentPage
{
    public Recommendations()
    {
        InitializeComponent();
    }
    public Recommendations(
        string choice,
        double sleep,
        double stress,
        double activity,
        double wellness,
        string status,
        string recommendation)
    {
        InitializeComponent();

        LblChoice.Text = $"Gender: {choice}";
        LblStatus.Text = $"Status: {status}";
        LblRecommendation.Text = recommendation;
    }

    private async void BtnRslts_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void BtnRestart_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
