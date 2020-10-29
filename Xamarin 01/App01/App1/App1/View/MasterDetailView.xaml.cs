using App1.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : MasterDetailPage
    {
        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.Master = new MasterView(usuario);
        }
    }
}