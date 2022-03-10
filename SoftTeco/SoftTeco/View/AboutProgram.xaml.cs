using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SoftTeco.View
{
    public partial class AboutProgram : BasePage
    {
        public AboutProgram()
        {
            InitializeComponent();
            var widthScreen = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            var roundwidth = Math.Round(widthScreen, 1);
            VersionTracking.Track();
            NameProgramm.Text = "Название: " + AppInfo.Name ;
            NamePackProgramm.Text = "Название пакета: " + AppInfo.PackageName;
            BuildProgramm.Text = "Версия релиза: " + AppInfo.BuildString;
            VersionProgramm.Text = "Название релиза: " + AppInfo.VersionString;
            colorapp.Text = "Цветовая тема: " + AppInfo.RequestedTheme.ToString();
            Btn_width1.WidthRequest = (roundwidth * 95) / 100;
            Btn_width2.WidthRequest = (roundwidth * 95) / 100;
            Btn_width3.WidthRequest = (roundwidth * 95) / 100;

            Btn_width1.Padding = new Thickness(0, 0, roundwidth * 0.52 - Btn_width1.Text.Length, 0);
            Rect_width1.Margin = new Thickness(roundwidth * 0.10, 0, 0, 0);
            Btn_width2.Padding = new Thickness(0, 0, roundwidth * 0.53 - Btn_width2.Text.Length, 0);
            Rect_width2.Margin = new Thickness(roundwidth * 0.10, 0, 0, 0);
            Btn_width3.Padding = new Thickness(0, 0, roundwidth * 0.53 + Btn_width3.Text.Length, 0);
            Rect_width3.Margin = new Thickness(roundwidth * 0.10, 0, 0, 0);
        }
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnOpenBrowser_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var url = button.ClassId;
            await Browser.OpenAsync(url);
        }
    }
}