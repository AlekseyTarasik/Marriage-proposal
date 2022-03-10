using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftTeco.View.ViewTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FourthTaskPage : BasePage
    {
        int count = 1;
        readonly DateTime todayis = new DateTime(2022, 2, 18, 12, 30, 00);
        public FourthTaskPage()
        {
            InitializeComponent();
            if (DateTime.Now >= todayis)
            {
                BtnStart.IsEnabled = true;
            }
            else
                LblToday.Text = "Необходимо немножко подождать!" + todayis.ToString();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Task4_1.IsVisible = false;
            Task4_2.IsVisible = true;
        }
        private void BtnHelp_Clicked(object sender, EventArgs e)
        {
            count++;
            if (count <= 2)
            {
                Lbl4Help.IsVisible = true;
                Lbl4Help.Text = "Вы уверены, что вам нужна подсказка?";
            }
            else if (count > 2 && count <= 3)
            {
                Lbl4Help.Text = "Вы точно уверены, что она вам нужна?";
            }
            else if (count > 3)
            {
                Lbl4Help.IsVisible = false;
                Task4Help.IsVisible = true;
            }
        }
        private async void BtnCheck_Clicked(object sender, EventArgs e)
        {
            if (Task4_answer.Text.ToString() != "")
            {
                if ((Task4_answer.Text.ToString() == "курган славы") || (Task4_answer.Text.ToString() == "Курган славы") || (Task4_answer.Text.ToString() == "Курган славы ") || (Task4_answer.Text.ToString() == "курган славы "))
                {
                    Task4_answer.TextColor = Color.Green;
                    BtnTask4Start.IsEnabled = true;
                }
                else
                    Task4_answer.TextColor = Color.Red;
                await MyAsyncMethod();
            }
        }
        public async Task MyAsyncMethod()
        {
            await Task.Delay(2000);
            Task4_answer.TextColor = Color.FromHex("#B2B2B2");
        }
        CancellationTokenSource cts;
        private async void BtnStart_Clicked(object sender, EventArgs e)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
            cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);
            if (location != null)
            {
                double x = location.Longitude;
                double y = location.Latitude;
                if ((x > 27.893000 && x < 27.900000) && (y > 54.016500 && y < 54.020000))
                {
                    //App.myList[1] = 1;
                    Preferences.Set("my_key", "4");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Lbl5Place.IsVisible = true;
                    Lbl5Place.Text = "Вы не находитесь возле Кургана славы!";
                    Lbl5Place.TextColor = Color.Red;
                }
            }
        }
    }
}