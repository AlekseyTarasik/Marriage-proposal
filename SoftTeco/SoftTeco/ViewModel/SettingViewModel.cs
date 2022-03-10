using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using SoftTeco.Helpers;
using SoftTeco.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SoftTeco.ViewModel
{
    class SettingViewModel: BaseViewModel
    {
        string uri = "https://sites.google.com/softteco.com/softtecointranet/о-компании";
        string subject = "Application powered by SoftTeco company";
        string title = "SoftTeco";

        public ICommand RequestCommand { get; }
        public ICommand BtnAboutProgClick { get; set; }
        public ICommand BtnAboutEmpClick { get; set; }
        public ICommand BtnSuppClick { get; set; }

        public SettingViewModel()
        {
        }
        public SettingViewModel(INavigation navigation): base(navigation)
        {
            BtnAboutProgClick = new Command(async () => {
                await Navigation.PushAsync(new AboutProgram());
            });
            BtnAboutEmpClick = new Command(async () => {
                await Navigation.PushAsync(new AboutEmployee());
            });
            BtnSuppClick = new Command(async () => {
                await Navigation.PushAsync(new EmailPage());
            });
            RequestCommand = new Command<Xamarin.Forms.View>(OnRequest);
        }

        public string Uri
        {
            get => uri;
            set => SetProperty(ref uri, value);
        }

        public string Subject
        {
            get => subject;
            set => SetProperty(ref subject, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        async void OnRequest(Xamarin.Forms.View element)
            => await Share.RequestAsync(new ShareTextRequest
            {
                Subject = Subject,
                Uri = Uri,
                Title = Title,
                PresentationSourceBounds = GetRectangle(element)
            });
        System.Drawing.Rectangle GetRectangle(Xamarin.Forms.View element) => element.GetAbsoluteBounds().ToSystemRectangle();
    }
}
