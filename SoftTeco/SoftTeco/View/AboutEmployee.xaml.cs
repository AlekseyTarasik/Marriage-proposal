using System;
using Xamarin.Forms.Xaml;
using SoftTeco.ViewModel;

namespace SoftTeco.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutEmployee : BasePage
    {
        public AboutEmployee()
        {
            InitializeComponent();
            BindingContext = new AboutEmployeeViewModel();
        }
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}