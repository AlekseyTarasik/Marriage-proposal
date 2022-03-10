using SoftTeco.ViewModel;

namespace SoftTeco.View
{
    public partial class EmailPage : BasePage
    {
        public EmailPage()
        {
            InitializeComponent();
            BindingContext = new EmailViewModel();
        }
    }
}
