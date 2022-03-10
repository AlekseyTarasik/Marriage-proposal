using SoftTeco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SoftTeco
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation);
            SecondBtn.IsEnabled = false;
            ThirdtBtn.IsEnabled = false;
            ForthBtn.IsEnabled = false;
            FifthBtn.IsEnabled = false;
            GalleryBtn.IsEnabled = false;
            GalleryLbl.Opacity = 0.4;
            var myValue = Preferences.Get("my_key", "default_value");
            int elem = Convert.ToInt32(myValue);
            if (elem >= 0)
            {
                FirstBtn.IsEnabled = true;
                if (elem >= 1)
                {
                    SecondBtn.IsEnabled = true;
                    if (elem >= 2)
                    {
                        ThirdtBtn.IsEnabled = true;
                        if (elem >= 3)
                        {
                            ForthBtn.IsEnabled = true;
                            if (elem >= 4)
                            {
                                FifthBtn.IsEnabled = true;
                                if (elem >= 5)
                                {
                                    GalleryBtn.IsEnabled = true;
                                }
                            }
                        }
                    }
                }
            }
            Navigation.NavigationStack.ToList().Clear();
            
        }
    }
}
