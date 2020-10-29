using App1.Model;
using App1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : ContentPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = new MasterViewModel(usuario);
        }
    }
}