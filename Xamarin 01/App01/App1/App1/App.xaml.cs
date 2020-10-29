using App1.Model;
using App1.View;
using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "LoginSucesso", (usuario) =>
            {
                MainPage = new MasterDetailView(usuario);
            });
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
    }
}
