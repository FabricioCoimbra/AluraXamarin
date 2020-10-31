using App1.iOS;
using App1.Media;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Application))]
namespace App1.iOS
{
    public class Application: ICamera
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        public void TirarFoto()
        {
        }
    }
}
