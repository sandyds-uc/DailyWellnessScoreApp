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

    private void Btn_Clicked(object sender, EventArgs e)
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
                    recommendation = "Maintain routine; include resistance training 2–3× per week; ensure protein intake across meals.";
                    break;
                case "Good":
                    recommendation = "Improve recovery with an earlier bedtime; add 15 min of light cardio or stretching; keep hydration steady.";
                    break;
                case "Fair":
                    recommendation = "Aim for +1 hour of sleep; reduce caffeine after noon; schedule light mobility or an easy walk.";
                    break;
                default:
                    recommendation = "Rest today; avoid strenuous workouts; focus on hydration and 20–30 min of gentle walking.";
                    break;
            }
        else
            switch (status)
            {
                case "Excellent":
                    recommendation = "Keep strong habits; add yoga/pilates for recovery; prioritize calcium + vitamin D intake.";
                    break;
                case "Good":
                    recommendation = "Boost energy with a balanced breakfast; add 15 min of walking; focus on iron-rich foods if feeling low.";
                    break;
                case "Fair":
                    recommendation = "Increase sleep consistency; reduce evening screen time; include calming routines like meditation or journaling.";
                    break;
                default:
                    recommendation = "Prioritize rest and self-care; consider a short nap if possible; gentle yoga/stretching only.";
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
        LblScore.Text = wellness.ToString("F0");
        LblStatus.Text = status;
        LblRecommendation.Text = recommendation;
    }
}