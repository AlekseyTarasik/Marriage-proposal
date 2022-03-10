using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftTeco.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstTaskPage : BasePage
    {
        int truecount = 0;
        readonly DateTime my1date = new DateTime(2020, 7, 15);
        readonly DateTime my2date = new DateTime(2020, 7, 24);
        readonly DateTime my3date = new DateTime(2020, 7, 18);
        readonly DateTime todayis = new DateTime(2022, 2, 13, 10, 00, 00);
        public FirstTaskPage()
        {
            InitializeComponent();
            if (DateTime.Now >= todayis)
            {
                BtnStart.IsEnabled = true;
            }
            else
                LblToday.Text = "Необходимо немножко подождать!" + todayis.ToString();
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            Task1_1.IsVisible = false;
            Task1_2.IsVisible = true;
            SW1.IsToggled = true;
            BtnEnter.IsEnabled = false;
        }
        void OnToggled(object sender, ToggledEventArgs e)
        {
            if (SW1.IsToggled == true) {
                Switch1On.IsVisible = true;
                Switch2On.IsVisible = false;
                Switch3On.IsVisible = false;
                SW2.IsEnabled = false;
                SW3.IsEnabled = false;
            }
            else if (SW2.IsToggled == true) {
                Switch1On.IsVisible = false;
                Switch2On.IsVisible = true;
                Switch3On.IsVisible = false;
                SW1.IsEnabled = false;
                SW3.IsEnabled = false;
            }
            else if (SW3.IsToggled == true) {
                Switch1On.IsVisible = false;
                Switch2On.IsVisible = false;
                Switch3On.IsVisible = true;
                SW1.IsEnabled = false;
                SW2.IsEnabled = false;
            }
        }
        private async void BtnCheck_Clicked(object sender, EventArgs e)
        {
            if (truecount == 0)
            {
                if ((EditFirst.Text == "Висячий замок" || EditFirst.Text == "висячий замок" || EditFirst.Text == "замок" || EditFirst.Text == "Замок") &&
                    (EditSecon.Text == "Париж" || EditSecon.Text == "париж") &&
                    (EditThir.Text == "без цветов" || EditThir.Text == "Без цветов" || EditThir.Text == "цветы" || EditThir.Text == "Цветы" || EditThir.Text == "деньги" || EditThir.Text == "Деньги" || EditThir.Text == "Без денег" || EditThir.Text == "без денег" || EditThir.Text == "без букета" || EditThir.Text == "букет") &&
                    (EditFour.Text == "А.С.Пушкин" || EditFour.Text == "А.С. Пушкин" || EditFour.Text == "Пушкин" || EditFour.Text == "пушкин"))
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
                Switch1On.IsVisible = false;
                SW1.IsToggled = false;
                SW2.IsToggled = true;
                Switch2On.IsVisible = true;
                if ((Edit2Fi.Text == "" && Edit2Se.Text == "" && Edit2Th.Text == "" && Edit2Fo.Text == "") || (Edit2Fi.Text == " " && Edit2Se.Text == " " && Edit2Th.Text == " " && Edit2Fo.Text == " "))
                {
                    Check2On.IsVisible = false;
                }
                else if ((Edit2Fi.Text == "Сердце" || Edit2Fi.Text == "сердце" || Edit2Fi.Text == "лебедь" || Edit2Fi.Text == "Лебедь") &&
                    (Edit2Se.Text == "Americano" || Edit2Se.Text == "americano" || Edit2Se.Text == "американо" || Edit2Se.Text == "Американо") &&
                    (Edit2Th.Text == "на ромашке" || Edit2Th.Text == "На ромашке" || Edit2Th.Text == "Ромашка" || Edit2Th.Text == "ромашка") &&
                    (Edit2Fo.Text == "Kiosque" || Edit2Fo.Text == "kiosque" || Edit2Fo.Text == "Киоск" || Edit2Fo.Text == "киоск" || Edit2Fo.Text == "в киоске"))
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
                    Check2On.IsVisible = true;
                }
            }
            else if (truecount == 2)
            {
                Switch2On.IsVisible = false;
                SW2.IsToggled = false;
                SW3.IsToggled = true;
                Switch3On.IsVisible = true;
                if (Pick1.Date == DateTime.Today && Pick2.Date == DateTime.Today && Pick3.Date == DateTime.Today)
                {
                    Check3On.IsVisible = false;
                }
                else if (Pick1.Date == my1date && Pick2.Date == my2date && Pick3.Date == my3date)
                {
                    Check3On.IsVisible = true;
                    Check3On.Text = "Осталось только посетить место вашей первой встречи и сделать там замечательную фотографию!";
                    Check3On.HorizontalTextAlignment = TextAlignment.Center;
                    Check4On.IsVisible = true;
                    await MyAsyncMethod();
                    Check4On.Text = "Посетите место вашей первой встречи, следующее задание откроется именно там!";
                    Check4On.HorizontalTextAlignment = TextAlignment.Center;
                    Check4On.FontSize = 25;
                    BtnEnter.IsEnabled = true;
                }
                else
                {
                    Check3On.IsVisible = true;
                    Check3On.Text = "Видимо, даты близки к правильным, но не те!";
                }
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
                if ((x > 27.573500 && x < 27.575500) && (y > 53.892500 && y < 53.894000))
                {
                    Preferences.Set("my_key", "1");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Check4On.TextColor = Color.Red;
                }
            }
        }
    }
}