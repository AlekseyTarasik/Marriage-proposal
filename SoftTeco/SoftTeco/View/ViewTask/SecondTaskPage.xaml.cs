using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftTeco.View.ViewTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondTaskPage : BasePage
    {
        readonly DateTime todayis = new DateTime(2022, 2, 15, 12, 30, 00);
        int truecount = 0;
        public SecondTaskPage()
        {
            InitializeComponent();
            LblToday.IsVisible = true;
            if (DateTime.Now >= todayis)
            {
                BtnStart.IsEnabled = true;
            }
            else
            {
                LblToday.Text = "Необходимо немножко подождать!" + todayis.ToString();
            }
        }
        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            Task2_1.IsVisible = false;
            Task2_2.IsVisible = true;
            Task2_2_1.IsVisible = true;
        }
        private async void BtnCheck_Clicked(object sender, EventArgs e)
        {
            if (truecount == 0)
            {
                if (RadBtn1_1.IsChecked == true && RadBtn2_1.IsChecked == true && (Edit2_1.Text == "Маргарет" || Edit2_1.Text == "маргарет" || Edit2_1.Text == "Margaret") && RadBtn3_1.IsChecked == true)
                {
                    Check1On.Text = "Всё верно";
                    Check1On.TextColor = Color.Green;
                    Check1On.IsVisible = true;
                    truecount++;
                    await MyAsyncMethod();
                }
                else
                {
                    Check1On.Text = "Неправильно";
                    Check1On.TextColor = Color.Red;
                    Check1On.IsVisible = true;
                }
            }
            else if (truecount == 1)
            {
                Task2_2_1.IsVisible = false;
                Task2_2_2.IsVisible = true;
                if (RadBtn4_1.IsChecked == false && RadBtn5_1.IsChecked == false && RadBtn6_1.IsChecked == false && RadBtn7_1.IsChecked == false && RadBtn8_1.IsChecked == false && RadBtn9_1.IsChecked == false && RadBtn10_1.IsChecked == false)
                {
                    Check2On.IsVisible = false;
                }
                else if (RadBtn4_1.IsChecked == true && RadBtn5_1.IsChecked == true && RadBtn6_1.IsChecked == true && RadBtn7_1.IsChecked == true && RadBtn8_1.IsChecked == true && RadBtn9_1.IsChecked == true && RadBtn10_1.IsChecked == true)
                {
                    Check2On.Text = "Всё верно";
                    Check2On.TextColor = Color.Green;
                    Check2On.IsVisible = true;
                    truecount++;
                    await MyAsyncMethod();
                }
                else
                {
                    Check2On.Text = "Неправильно";
                    Check2On.TextColor = Color.Red;
                    Check2On.IsVisible = true;
                }
            }
            else if (truecount == 2)
            {
                Task2_2_2.IsVisible = false;
                Task2_2_3.IsVisible = true;
                BtnCheck.IsVisible = false;
                BtnEnter.IsVisible = true;
            }
        }
        public async Task MyAsyncMethod()
        {
            await Task.Delay(3000);
        }
        CancellationTokenSource cts;
        private async void BtnEnter_Clicked(object sender, EventArgs e)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
            cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);
            if (location != null)
            {
                double x = location.Longitude;
                double y = location.Latitude;
                if ((x > 27.482300 && x < 27.484000) && (y > 53.863500 && y < 53.864600))
                {
                    //App.myList[1] = 1;
                    Preferences.Set("my_key", "2");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Check3On.IsVisible = true;
                    Check3On.Text = "Вы не находитесь возле кинотеатра!";
                    Check3On.TextColor = Color.Red;
                }
            }
        }
    }
 }