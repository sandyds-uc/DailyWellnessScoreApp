using Android.Health.Connect.DataTypes;
using Android.Speech.Tts;
using Java.Text;
using System.Threading.Tasks;

namespace DailyWellnessScoreApp;

public partial class WellnessResult : ContentPage
{
	string choice;
	double sleep;
	double stress;
	double activity;
	double wellness;
	string status;
	string recommendation;

    public WellnessResult(
		string choice,
		double sleep,
		double stress,
		double activity,
		double wellness,
		string status,
		string recommendation)
	{
		InitializeComponent();
        this.choice = choice;
        this.sleep = sleep;
        this.stress = stress;
        this.activity = activity;
        this.wellness = wellness;
        this.status = status;
        this.recommendation = recommendation;

        LblScore.Text = wellness.ToString("F0");
		LblStatus.Text = $"Status: {status}";
		// LblRecommendation.Text = recommendation; 
	}

    private async void BtnRec_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Recommendations(choice, sleep, stress, activity, wellness, status, recommendation));

    }

    private async void BtnInp_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();

    }
}