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
    }
}