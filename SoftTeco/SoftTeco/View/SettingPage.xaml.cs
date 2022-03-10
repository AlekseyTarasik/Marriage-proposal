using SoftTeco.ViewModel;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace SoftTeco.View
{
    public partial class SettingPage : BasePage
    {
         public SettingPage()
        {
            InitializeComponent();
            BindingContext = new SettingViewModel(Navigation);

            var widthScreen = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            var roundwidth = Math.Round(widthScreen, 1);
            BtnFirst.WidthRequest = (roundwidth * 95) / 100;
            BtnSecond.WidthRequest = (roundwidth * 95) / 100;
            BtnThird.WidthRequest = (roundwidth * 95) / 100;
            BtnFourth.WidthRequest = (roundwidth * 95) / 100;
            
            BtnFirst.Padding = new Thickness(-(roundwidth * 0.57112), 0, 0, 0);
            BtnSecond.Padding = new Thickness(-(widthScreen * 0.26737), 0, 0, 0);
            BtnThird.Padding = new Thickness(-(widthScreen * 0.64414), 0, 0, 0);
            BtnFourth.Padding = new Thickness(-(widthScreen * 0.27710), 0, 0, 0);
        }
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}