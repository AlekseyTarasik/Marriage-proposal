using SoftTeco.ViewModel;
using System;
using System.Collections.Generic;
using Windows.Storage;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftTeco
{
    public partial class App : Application
    {
        DateTime todayis = new DateTime(2022, 2, 18, 20, 10, 00);
        public static List<int> myList { get; set; }
        public App()
        {
            InitializeComponent();
            if (DateTime.Now >= todayis)
            {
                Preferences.Set("my_key", "5");
            }
            else
                Preferences.Set("my_key", "3");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume");
        }
    }
}
