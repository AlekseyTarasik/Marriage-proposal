using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftTeco.View.ViewTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdTaskPage : BasePage
    {
        int PeopCount;
        int EnterClick = 0;
        readonly DateTime todayis = new DateTime(2022, 2, 17, 12, 30, 00);
        public ThirdTaskPage()
        {
            InitializeComponent();
            LblToday.IsVisible = true;
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
            Task3_1.IsVisible = false;
            Task3_2.IsVisible = true;
            BtnEnter.IsEnabled = false;
        }
        CancellationTokenSource cts;
        private async void BtnEnter_Clicked(object sender, EventArgs e)
        {
            if (EnterClick == 0)
            {
                Task3_2.IsVisible = false;
                Task3_3.IsVisible = true;
                EnterClick++;
            }
            else
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                if (location != null)
                {
                    double x = location.Longitude;
                    double y = location.Latitude;
                    if ((x > 27.549000 && x < 27.551500) && (y > 53.889600 && y < 53.891000))
                    {
                        Preferences.Set("my_key", "3");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        Check3On.IsVisible = true;
                        Check3On.Text = "Вы не находитесь на вокзале!";
                        Check3On.TextColor = Color.Red;
                    }
                }
            }
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            Slider2.Text = String.Format("{0}", value);
            PeopCount = Convert.ToInt32(value);
        }
        public async Task MyAsyncMethod()
        {
            await Task.Delay(5000);
        }
        private async void BtnCheck_Clicked(object sender, EventArgs e)
        {
            /*
            if ((RadBtn1_3.IsChecked == true) && (PeopCount >= 2000000 && 2100000 >= PeopCount) && (RadBtn3_5.IsChecked == true) &&
                (Edit1_4.Text == "Вокзал" || Edit1_4.Text == "вокзал") && (RadBtn5_2.IsChecked == true) && (RadBtn6_3.IsChecked == true) &&
                (Edit1_2.Text == "голубой вагон" || Edit1_2.Text == "Голубой вагон" || Edit1_2.Text == "Постой, паровоз" ||
                    Edit1_2.Text == "постой паровоз" || Edit1_2.Text == "Постой паровоз" || Edit1_2.Text == "постой, паровоз" ||
                    Edit1_2.Text == "Опять от меня сбежала последняя электричка" || Edit1_2.Text == "опять от меня сбежала последняя электричка" || Edit1_2.Text == "последняя электричка" ||
                    Edit1_2.Text == "последняя электричка" || Edit1_2.Text == "электричка" || Edit1_2.Text == "Электричка") &&
                    (Check1.IsChecked == true && Check2.IsChecked == true && Check3.IsChecked == true && Check4.IsChecked == true &&
                    Check5.IsChecked == true && Check6.IsChecked == true && Check7.IsChecked == true))
            {
                Lbl1_8.Text = "Всё правильно";
                Lbl1_8.TextColor = Color.Green;
                Lbl1_8.IsVisible = true;
                BtnEnter.IsEnabled = true;
            }
            else
            {
                Lbl1_8.Text = "Всё неправильно!";
                Lbl1_8.TextColor = Color.Red;
                Lbl1_8.IsVisible = true;
                await Task.Delay(5000);
                Lbl1_8.IsVisible = false;
            }
            */
            
            if (RadBtn3_1.IsChecked == true)
            {
                if (PeopCount >= 1950000 && 2020000 >= PeopCount)
                {
                    if (RadBtn3_2.IsChecked == true)
                    {
                        if (RadBtn3_3.IsChecked == true)
                        {
                            if (RadBtn3_4.IsChecked == true)
                            {
                                if (RadBtn3_5.IsChecked == true)
                                {
                                    if (Edit1_1.Text == "Вокзал" || Edit1_1.Text == "вокзал" || Edit1_1.Text == "набережная" || Edit1_1.Text == "Набережная")
                                    {
                                        if (RadBtn3_6.IsChecked == true)
                                        {
                                            if (RadBtn3_7.IsChecked == true)
                                            {
                                                if (Edit1_2.Text == "голубой вагон" || Edit1_2.Text == "Голубой вагон" || Edit1_2.Text == "Постой, паровоз" ||
                                                    Edit1_2.Text == "постой паровоз" || Edit1_2.Text == "Постой паровоз" || Edit1_2.Text == "постой, паровоз" ||
                                                    Edit1_2.Text == "Опять от меня сбежала последняя электричка" || Edit1_2.Text == "опять от меня сбежала последняя электричка" || Edit1_2.Text == "последняя электричка" ||
                                                    Edit1_2.Text == "последняя электричка" || Edit1_2.Text == "электричка" || Edit1_2.Text == "Электричка")
                                                {
                                                    if (Check1.IsChecked == true && Check2.IsChecked == true && Check3.IsChecked == true && Check4.IsChecked == true &&
                                                        Check5.IsChecked == true && Check6.IsChecked == true && Check7.IsChecked == true)
                                                    {
                                                        BtnEnter.IsEnabled = true;
                                                    }
                                                    else
                                                    {
                                                        Lbl1_11.Text = "Неправильно!";
                                                        Lbl1_11.TextColor = Color.Red;
                                                        Lbl1_11.IsVisible = true;
                                                        await Task.Delay(5000);
                                                        Lbl1_11.IsVisible = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Lbl1_10.Text = "Неправильно!";
                                                    Lbl1_10.TextColor = Color.Red;
                                                    Lbl1_10.IsVisible = true;
                                                    await Task.Delay(5000);
                                                    Lbl1_10.IsVisible = false;
                                                }
                                            }
                                            else if (RadBtn3_7.IsChecked != true)
                                            {
                                                Lbl1_9.Text = "Неправильно!";
                                                Lbl1_9.TextColor = Color.Red;
                                                Lbl1_9.IsVisible = true;
                                                await Task.Delay(5000);
                                                Lbl1_9.IsVisible = false;
                                            }
                                        }
                                        else if (RadBtn3_6.IsChecked != true)
                                        {
                                            Lbl1_8.Text = "Неправильно!";
                                            Lbl1_8.TextColor = Color.Red;
                                            Lbl1_8.IsVisible = true;
                                            await Task.Delay(5000);
                                            Lbl1_8.IsVisible = false;
                                        }
                                    }
                                    else if (Edit1_1.Text != "Вокзал" || Edit1_1.Text != "вокзал" || Edit1_1.Text != "набережная" || Edit1_1.Text != "Набережная")
                                    {
                                        Lbl1_7.Text = "Неправильно!";
                                        Lbl1_7.TextColor = Color.Red;
                                        Lbl1_7.IsVisible = true;
                                        await Task.Delay(5000);
                                        Lbl1_7.IsVisible = false;
                                    }
                                }
                                else if (RadBtn3_5.IsChecked != true)
                                {
                                    Lbl1_6.Text = "Неправильно!";
                                    Lbl1_6.TextColor = Color.Red;
                                    Lbl1_6.IsVisible = true;
                                    await Task.Delay(5000);
                                    Lbl1_6.IsVisible = false;
                                }
                            }
                            else if (RadBtn3_4.IsChecked != true)
                            {
                                Lbl1_5.Text = "Неправильно!";
                                Lbl1_5.TextColor = Color.Red;
                                Lbl1_5.IsVisible = true;
                                await Task.Delay(5000);
                                Lbl1_5.IsVisible = false;
                            }
                        }
                        else if (RadBtn3_3.IsChecked != true)
                        {
                            Lbl1_4.Text = "Неправильно!";
                            Lbl1_4.TextColor = Color.Red;
                            Lbl1_4.IsVisible = true;
                            await Task.Delay(5000);
                            Lbl1_4.IsVisible = false;
                        }
                    }
                    else if (RadBtn3_2.IsChecked != true)
                    {
                        Lbl1_3.Text = "Неправильно!";
                        Lbl1_3.TextColor = Color.Red;
                        Lbl1_3.IsVisible = true;
                        await Task.Delay(5000);
                        Lbl1_3.IsVisible = false;
                    }
                }
                else if (PeopCount < 2000000 || PeopCount > 2100000)
                {
                    Lbl1_2.Text = "Население города вы могли бы знать и получе!";
                    Lbl1_2.TextColor = Color.Red;
                    Lbl1_2.IsVisible = true;
                    await Task.Delay(5000);
                    Lbl1_2.IsVisible = false;
                }
            }
            else if (RadBtn3_1.IsChecked != true)
            {
                Lbl1_1.Text = "Неправильно отгадано количество районов в Минске";
                Lbl1_1.TextColor = Color.Red;
                Lbl1_1.IsVisible = true;
                await Task.Delay(5000);
                Lbl1_1.IsVisible = false;
            }
        }
    }
}