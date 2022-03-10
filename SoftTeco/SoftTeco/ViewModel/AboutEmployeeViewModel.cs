using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SoftTeco.ViewModel
{
    public class AboutEmployeeViewModel : BaseViewModel
    {
        string surname = "Тарасик";
        string firstname;
        string patronymic;
        string citizenship;
        string aboutyourself;
        string phonenumber;
        string securedValue;
        public AboutEmployeeViewModel()
        {
            OnLoad();
            LoadCommand = new Command(OnLoad);
            SaveCommand = new Command(OnSave);
            RemoveCommand = new Command(OnRemove);
            RemoveAllCommand = new Command(OnRemoveAll);
        }

        public string SecuredValue
        {
            get
            {
                return Firstname + "|" + Patronymic + "|" + Citizenship + "|" + Phonenumber + "|" + Aboutyourself;
            }
            set
            {
                securedValue = value;
                string[] words = securedValue.Split(new char[] { '|' });
                Firstname = words[0];
                Patronymic = words[1];
                Citizenship = words[2];
                Phonenumber = words[3];
                Aboutyourself = words[4];
            }
        }
        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }
        public string Firstname
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }
        public string Patronymic
        {
            get => patronymic;
            set => SetProperty(ref patronymic, value);
        }
        public string Citizenship
        {
            get => citizenship;
            set => SetProperty(ref citizenship, value);
        }
        public string Phonenumber
        {
            get => phonenumber;
            set => SetProperty(ref phonenumber, value);
        }
        public string Aboutyourself
        {
            get => aboutyourself;
            set => SetProperty(ref aboutyourself, value);
        }

        public ICommand LoadCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand RemoveAllCommand { get; }

        async void OnLoad()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                SecuredValue = await SecureStorage.GetAsync(Surname) ?? string.Empty;
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync(ex.Message);
            }

            IsBusy = false;
        }

        async void OnSave()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                await SecureStorage.SetAsync(Surname, SecuredValue);
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync(ex.Message);
            }
            IsBusy = false;
        }

        async void OnRemove()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                SecureStorage.Remove(Surname);
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync(ex.Message);
            }
            IsBusy = false;
        }

        async void OnRemoveAll()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                SecureStorage.RemoveAll();
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync(ex.Message);
            }
            IsBusy = false;
        }
    }
}
