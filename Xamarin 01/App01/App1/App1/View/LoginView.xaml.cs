using App1.Erro;
using App1.ViewModel;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", (Erro) =>
            {
                DisplayAlert("Erro", Erro.Message, "OK");
                ((LoginViewModel)this.BindingContext).MsgErroLogin = Erro.Message;
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}