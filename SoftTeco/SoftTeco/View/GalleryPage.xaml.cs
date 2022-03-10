using SoftTeco.ViewModel;
using System;
using System.Collections.Generic;

namespace SoftTeco.View
{
    public partial class GalleryPage : BasePage
    {
        DateTime todayis = new DateTime(2022, 2, 18, 20, 00, 00);
        public GalleryPage()
        {
            InitializeComponent();

            var _gallery = new List<GalleryPag>();
            _gallery.Add(new GalleryPag { Title = "19.12.2020", ImagePath = "Resources/drawable/aPhoto_19122020.jpeg" });
            _gallery.Add(new GalleryPag { Title = "03.01.2021", ImagePath = "Resources/drawable/aPhoto_03012021.jpeg" });
            _gallery.Add(new GalleryPag { Title = "03.04.2021", ImagePath = "Resources/drawable/aPhoto_03042021.jpeg" });
            _gallery.Add(new GalleryPag { Title = "22.07.2021", ImagePath = "Resources/drawable/aPhoto_22072021.jpeg" });
            _gallery.Add(new GalleryPag { Title = "07.08.2021", ImagePath = "Resources/drawable/aPhoto_07082021_01.jpeg" });
            _gallery.Add(new GalleryPag { Title = "07.08.2021", ImagePath = "Resources/drawable/aPhoto_07082021_02.jpeg" });
            _gallery.Add(new GalleryPag { Title = "13.10.2021", ImagePath = "Resources/drawable/aPhoto_13102021_01.jpeg" });
            _gallery.Add(new GalleryPag { Title = "10.02.2022", ImagePath = "Resources/drawable/aPhoto_10022022.jpeg" });
            TheCarousel.ItemsSource = _gallery;

            LblToday.Text = CountableTask.CountTask.ToString();
            LblToday.IsVisible = true;
            if (DateTime.Now >= todayis)
            {
                TheCarousel.IsVisible = true;
                indicatorview.IsVisible = true;
            }
            else
                LblToday.Text = "Необходимо немножко подождать!" + todayis.ToString();
        }
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}