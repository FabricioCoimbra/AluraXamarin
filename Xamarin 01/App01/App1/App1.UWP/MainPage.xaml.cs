using App1.Media;
using App1.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(MainPage))]
namespace App1.UWP
{
    public sealed partial class MainPage: ICamera
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new App1.App());
        }

        public void TirarFoto()
        {
        }
    }
}
