using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SoftTeco.ViewModel
{
    public class EmailViewModel : BaseViewModel
    {
        string subject = "Предложение по работе приложения";
        string body = "В приложении не работает...\nНадеюсь на скорейшее исправление...";
        string recipientsTo = "NetDevelopDept@softteco.com";
        
        public EmailViewModel()
        {
            SendEmailCommand = new Command(OnSendEmail);
        }

        public ICommand SendEmailCommand { get; }

        public string Subject
        {
            get => subject;
            set => SetProperty(ref subject, value);
        }

        public string Body
        {
            get => body;
            set => SetProperty(ref body, value);
        }

        public string RecipientsTo
        {
            get => recipientsTo;
            set => SetProperty(ref recipientsTo, value);
        }

        public async void OnSendEmail()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                var message = new EmailMessage
                {
                    Subject = Subject,
                    Body = Body,
                    To = Split(RecipientsTo),
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await DisplayAlertAsync(fbsEx.Message);
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        List<string> Split(string recipients)
            => recipients?.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)?.ToList();
    }
}
