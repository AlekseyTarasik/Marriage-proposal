using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using SoftTeco.View;
using SoftTeco;
using SoftTeco.View.ViewTask;

namespace SoftTeco.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        { 
        }
        public ICommand BtnSettingClicked { get; }
        public ICommand BtnFirstClicked { get; }
        public ICommand BtnSecondClicked { get; }
        public ICommand BtnThirdClicked { get; }
        public ICommand BtnFourthClicked { get; }
        public ICommand BtnFifthClicked { get; }
        public ICommand BtnGalleryClicked { get; }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.BtnSettingClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new SettingPage());
            });
            this.BtnFirstClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new FirstTaskPage());
            });
            this.BtnSecondClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new SecondTaskPage());
            });
            this.BtnThirdClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new ThirdTaskPage());
            });
            this.BtnFourthClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new FourthTaskPage());
            });
            this.BtnFifthClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new FifthTaskPage());
            });
            this.BtnGalleryClicked = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new GalleryPage());
            });
            //this.BtnFirstClicked = new Command(async () => await GotoPage1());
        }

        /*public async Task GotoPage1()
        {
            await Navigation.PushAsync(new FirstTaskPage());
        }*/
    }
}
