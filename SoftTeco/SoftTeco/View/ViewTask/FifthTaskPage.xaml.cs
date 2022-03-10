using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace SoftTeco.View.ViewTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FifthTaskPage : BasePage
    {
        int count = 1;
        int count_b = 0;
        int check_1 = 0;        // некрасиво, но быстрее и читабельнее чем с массивом
        int check_2 = 0;
        int check_3 = 0;
        int check_4 = 0;
        int check_5 = 0;
        int check_6 = 0;
        int check_7 = 0;
        readonly DateTime todayis = new DateTime(2022, 2, 18, 20, 00, 00);
        public FifthTaskPage()
        {
            InitializeComponent();
            if (DateTime.Now >= todayis)
            {
                BtnStart.IsEnabled = true;
            }
            else
                LblToday.Text = "Необходимо немножко подождать!" + todayis.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Task5_1.IsVisible = false;
            Task5_2.IsVisible = true;
        }

        private async void BtnHelp_Clicked(object sender, EventArgs e)
        {
            count++;
            if (count == 2)
            {
                Lbl5Help.Text = "Подсказка №1";
                Lbl5Help1.Text = "В нём вы сможете познакомиться с гастрономической стороной Италии";
                Lbl5Help.IsVisible = true;
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(10000);
                Lbl5Help.IsVisible = false;
                Lbl5Help1.IsVisible = false;
            }
            else if (count == 4)
            {
                Lbl5Help.Text = "Подсказка №2";
                Lbl5Help1.Text = "За 19 месяцев вы так и не успели в нём побывать, но оочень хотели";
                Lbl5Help.IsVisible = true;
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(10000);
                Lbl5Help.IsVisible = false;
                Lbl5Help1.IsVisible = false;
            }
            else if (count == 6)
            {
                Lbl5Help.Text = "Подсказка №3";
                Lbl5Help1.Text = "Блюдо, которое вы скорее всего захотите там заказать, вы уже ели...   В Венеции...";
                Lbl5Help.IsVisible = true;
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(10000);
                Lbl5Help.IsVisible = false;
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnEnter_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("my_key", "5");
            await Navigation.PopAsync();
        }

        private async void BtnTrue_Clicked(object sender, EventArgs e)
        {
            count_b++;
            if(count_b >= 2)
            {
                Lbl5TF.Text = "Да, вы угадали, именно сейчас вы туда и отправитесь!";
                Lbl5TF.IsVisible = true;
                await MyAsyncMethod(10000);
                Lbl5TF.IsVisible = false;
                Task5_2.IsVisible = false;
                Task5_3.IsVisible = true;
            }
            else
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnCheck_Clicked1(object sender, EventArgs e)
        {
            check_1++;
            if (check_1 == 1)
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
            else
            {
                Lbl5Help1.Text = "Вы не угадали... Воспользуйтесь подсказкой...";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnCheck_Clicked2(object sender, EventArgs e)
        {
            check_2++;
            if (check_2 == 1)
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
            else
            {
                Lbl5Help1.Text = "Вы не угадали... Воспользуйтесь подсказкой...";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnCheck_Clicked3(object sender, EventArgs e)
        {
            check_3++;
            if (check_3 == 1)
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
            else
            {
                Lbl5Help1.Text = "Вы не угадали... Воспользуйтесь подсказкой...";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnCheck_Clicked4(object sender, EventArgs e)
        {
            check_4++;
            if (check_4 == 1)
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
            else
            {
                Lbl5Help1.Text = "Вы не угадали... Воспользуйтесь подсказкой...";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnCheck_Clicked5(object sender, EventArgs e)
        {
            check_5++;
            if (check_5 == 1)
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
            else
            {
                Lbl5Help1.Text = "Вы не угадали... Воспользуйтесь подсказкой...";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnCheck_Clicked6(object sender, EventArgs e)
        {
            check_6++;
            if (check_6 == 1)
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
            else
            {
                Lbl5Help1.Text = "Вы не угадали... Воспользуйтесь подсказкой...";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }
        private async void BtnCheck_Clicked7(object sender, EventArgs e)
        {
            check_7++;
            if (check_7 == 1)
            {
                Lbl5Help1.Text = "Вы уверены?";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
            else
            {
                Lbl5Help1.Text = "Вы не угадали... Воспользуйтесь подсказкой...";
                Lbl5Help1.IsVisible = true;
                await MyAsyncMethod(1500);
                Lbl5Help1.IsVisible = false;
            }
        }

        public async Task MyAsyncMethod(int count)
        {
            await Task.Delay(count);
        }
        private async void BtnStart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}