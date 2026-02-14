namespace DailyWellnessScoreApp;

public partial class DailyWellnessScore : ContentPage
{
    public DailyWellnessScore()
    {
        InitializeComponent();
        choice = "Male";
        FrameMale.BorderColor = Color.FromArgb("#0a0e29");
        FrameFemale.BorderColor = Color.FromArgb("#fdfdfd");
    }
    string choice = "Male";
    //string sleep = "7.0";
    //string stress = "4";
    //string activity = "30";

    private void TapMale_Tapped(object sender, EventArgs e)
    {
        choice = "Male";
        FrameMale.BorderColor = Color.FromArgb("#0a0e29");
        FrameFemale.BorderColor = Color.FromArgb("#fdfdfd");
    }

    private void TapFemale_Tapped(object sender, EventArgs e)
    {
        choice = "Female";
        FrameFemale.BorderColor = Color.FromArgb("#0a0e29");
        FrameMale.BorderColor = Color.FromArgb("#fdfdfd");

    }

    private async void Btn_Clicked(object sender, EventArgs e)
    {

        //double sleep = double.Parse(LblSleep.Text);
        //double stress = double.Parse(LblStress.Text);
        //double activity = double.Parse(LblActivity.Text);

        double sleep = SliderSleep.Value;
        double stress = SliderStress.Value;
        double activity = SliderActivity.Value;

        double wellness = (sleep * 8) - (stress * 5) + (activity * 0.5);
        wellness = Math.Clamp(wellness, 0, 100);
        wellness = Math.Round(wellness, 0, MidpointRounding.AwayFromZero);

        string status;

        switch (wellness)
        {
            case >= 80:
                status = "Excellent";
                break;
            case >= 60:
                status = "Good";
                break;
            case >= 40:
                status = "Fair";
                break;
            default:
                status = "Poor";
                break;
        }

        string recommendation = "";

        if (choice == "Male")
            switch (status)
            {
                case "Excellent":
                    recommendation = "Maintain routine; include resistance training 2–3×/week; ensure protein intake across meals.";
                    break;
                case "Good":
                    recommendation = "Earlier bedtime for recovery; add 15 min light cardio/stretching; maintain hydration.";
                    break;
                case "Fair":
                    recommendation = "Aim for +1 hour sleep; reduce caffeine after noon; schedule light mobility/easy walk.";
                    break;
                default:
                    recommendation = "Rest today; avoid strenuous workouts; hydrate and take 20–30 min gentle walk.";
                    break;
            }
        else
            switch (status)
            {
                case "Excellent":
                    recommendation = "Keep strong habits; add yoga/pilates for recovery; prioritize calcium + vitamin D intake.";
                    break;
                case "Good":
                    recommendation = "Balanced breakfast; add 15 min walking; focus on iron-rich foods if feeling low.";
                    break;
                case "Fair":
                    recommendation = "Improve sleep consistency; reduce evening screen time; add calming routines (meditation/journaling).";
                    break;
                default:
                    recommendation = "Prioritize rest/self-care; short nap if possible; gentle yoga/stretching only.";
                    break;
            }

        string WellnessMsg = $"Gender: {choice}\n" +
                             $"Sleep Hours: {sleep:F1}\n" +
                             $"Stress: {stress:F0}\n" +
                             $"Activity Minutes: {activity:F0}\n\n" +
                             $"Overall Wellness Score: {wellness:F0}\n" +
                             $"Rate: {status}\n\n" +
                             $"Recommendation:\n{recommendation}";

        //  DisplayAlert("Summary:", WellnessMsg, "Restart");
        // LblScore.Text = wellness.ToString("F0");
        // LblStatus.Text = status;
        // LblRecommendation.Text = recommendation;

        await Navigation.PushAsync(new WellnessResult(choice, sleep, stress, activity, wellness, status, recommendation));
    }
}