using App1.Model;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            LogoXamarin.Source = ImageSource.FromResource("App1.img.xamarin.jpg", typeof(LoginView).GetTypeInfo().Assembly);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<Usuario>(new Usuario(), "LoginSucesso");
        }
    }
}